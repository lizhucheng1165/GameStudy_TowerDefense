using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] private int m_monsterId;
    [SerializeField] private string m_monsterName;
    [SerializeField] private string m_description;
    [SerializeField] private float m_size;
    [SerializeField] private float m_maxHealth;
    [SerializeField] private float m_currentHealth;
    [SerializeField] private float m_healthRegeneration;
    [SerializeField] private float m_armor;
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_damageReduceMultiplier;
    [SerializeField] private float m_statusEffectReduceMultiplier;

    public int monsterId { get { return m_monsterId; } set { m_monsterId = value; } }
    public string monsterName { get { return m_monsterName; } set { m_monsterName = value; } }
    public string description { get { return m_description; } set { m_description = value; } }
    public float size { get { return m_size; } set { m_size = value; } }
    public float maxHealth { get { return m_maxHealth; } set { m_maxHealth = value; } }
    public float currentHealth { get { return m_currentHealth; } set { m_currentHealth = value; } }
    public float healthRegeneration { get { return m_healthRegeneration; } set { m_healthRegeneration = value; } }
    public float armor { get { return m_armor; } set { m_armor = value; } }
    public float moveSpeed { get { return m_moveSpeed; } set { m_moveSpeed = value; } }
    public float damageReduceMultiplier { get { return m_damageReduceMultiplier; } set { m_damageReduceMultiplier = value; } }
    public float statusEffectReduceMultiplier { get { return m_statusEffectReduceMultiplier; } set { m_statusEffectReduceMultiplier = value; } }

    private Transform[] waypoints;
    private int currentWaypoint = 0;

    private Image m_healthBarFront;
    private Image m_healthBarBack;
    private TextMeshProUGUI m_tmpDamage;

    private float m_healthBarDuration = 2f;
    private float m_damageDuration = 0.7f;

    private bool m_isDead = false;

    private void Awake()
    {
        waypoints = new Transform[4];
        for (int i = 0; i < 4; i++)
        {
            waypoints[i] = GameObject.Find("Waypoint_"+i).transform;
        }

        m_healthBarFront = transform.Find("Canvas/Image_HPBar_Front").GetComponent<Image>();
        m_healthBarBack = transform.Find("Canvas/Image_HPBar_Back").GetComponent<Image>();
        m_tmpDamage = transform.Find("Canvas/TMP_Damage").GetComponent<TextMeshProUGUI>();
        m_healthBarFront.enabled = false;
        m_healthBarBack.enabled = false;
        m_tmpDamage.enabled = false;
        EventBus.Subscribe(EventBusType.SPAWN_FINALBOSS, Death);
    }

    private void Update()
    {
        // 현재 웨이포인트로 이동
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, m_moveSpeed * Time.deltaTime);

        // 현재 웨이포인트에 도착하면 다음 웨이포인트로 이동
        if (transform.position == waypoints[currentWaypoint].position)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0; // 마지막 웨이포인트에 도달하면 처음으로 돌아감
            }
        }
    }

    public float TakeDamage(Bullet bullet)
    {
        if (m_isDead)
            return 0;

        float finalDamage = calcCritDamage((bullet.damage - (bullet.damage * m_damageReduceMultiplier) - m_armor), bullet.critcalChance, bullet.criticalDamageMultiplier);

        m_currentHealth -= finalDamage;

        StartCoroutine(ShowImage(m_healthBarDuration, m_healthBarBack));
        StartCoroutine(ShowImage(m_healthBarDuration, m_healthBarFront));
        StartCoroutine(ShowTMP(m_damageDuration, m_tmpDamage));
        StartCoroutine(RegenerationHealth());

        if (m_currentHealth < 0)
        {
            Death();
        }
        return finalDamage;
    }
    
    private void updateHealthBar()
    {
        float healthBarXSize = m_healthBarBack.rectTransform.sizeDelta.x;
        float updatedHealthBarSizeX = healthBarXSize * (m_currentHealth / m_maxHealth);

        if (updatedHealthBarSizeX >= 0)
            m_healthBarFront.rectTransform.sizeDelta = new Vector2(updatedHealthBarSizeX, m_healthBarFront.rectTransform.sizeDelta.y);
    }

    private float calcCritDamage(float damage, float towerCritChance, float towerCritDamage)
    {
        float finalDamage = damage;
        float critChance = Random.Range(0f, 1f);
        bool isCrit = false;


        if (critChance <= towerCritChance)
        {
            isCrit = true;
            finalDamage = damage * towerCritDamage;
        }

        if (finalDamage <= 0)
            finalDamage = 1;

        updateDamageTmp(isCrit, finalDamage);

        return finalDamage;
    }

    private void updateDamageTmp(bool isCrit, float finalDamage)
    {
        if (isCrit)
        {
            m_tmpDamage.text = string.Format("{0:F0}", finalDamage) + "!!";
            m_tmpDamage.color = new Color(1f, 0.3f, 0, 1);
            m_tmpDamage.fontStyle = FontStyles.Bold | FontStyles.Italic;
            return;
        }

        m_tmpDamage.text = string.Format("{0:F0}", finalDamage);
        m_tmpDamage.color = Color.white;
        m_tmpDamage.fontStyle = 0;

    }

    private void Death()
    {
        if (monsterId == 1000)
            SceneManager.LoadScene("End");

        m_isDead = true;
        EventBus.Publish(EventBusType.MONSTER_DEATH);
        if (GameInstance.Instance.gameManager.GetComponent<GameManager>().spawnedMonsters.Remove(this))
            Destroy(gameObject);  //Destroy(gameObject);
    }

    IEnumerator ShowTMP(float duration, TextMeshProUGUI tmp)
    {
        tmp.enabled = true;

        while (duration >= 0)
        {
            duration -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        tmp.enabled = false;
    }

    IEnumerator ShowImage(float duration, Image image)
    {
        image.enabled = true;

        while (duration >= 0)
        {
            duration -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        image.enabled = false;
    }

    IEnumerator RegenerationHealth()
    {
        while (!m_isDead)
        {
            if (m_currentHealth > maxHealth)
            {
                m_currentHealth = maxHealth;
                continue;
            }
            m_currentHealth += m_healthRegeneration / 10;
            updateHealthBar();

            yield return new WaitForSeconds(0.1f);
        }
    }
}
