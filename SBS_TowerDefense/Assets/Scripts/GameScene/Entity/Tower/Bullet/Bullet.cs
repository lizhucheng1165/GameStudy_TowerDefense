using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int m_bulletId;
    [SerializeField] private float m_damage;
    [SerializeField] private float m_speed;
    [SerializeField] private float m_penetration;
    [SerializeField] private float m_penetrationMultiplier;
    [SerializeField] private float m_critcalChance;
    [SerializeField] private float m_criticalDamageMultiplier;
    [SerializeField] private List<BulletEffect> m_bulletEffects;

    private Tower m_tower;
    private Vector3 m_targetTransform;

    public int bulletId { get { return m_bulletId; } set { m_bulletId = value; } }
    public float damage { get { return m_damage; } set { m_damage = value; } }
    public float speed { get { return m_speed; } set { m_speed = value; } }
    public float penetration { get { return m_penetration; } set {m_penetration = value; } }
    public float penetrationMultiplier { get { return m_penetrationMultiplier; } set { m_penetrationMultiplier = value; } }
    public float critcalChance { get { return m_critcalChance; } set { m_critcalChance = value; } }
    public float criticalDamageMultiplier { get { return m_criticalDamageMultiplier; } set { m_criticalDamageMultiplier = value; } }
    public List<BulletEffect> bulletEffects { get { return m_bulletEffects; } set { m_bulletEffects = value; } }
    public Tower tower {  get { return m_tower; } set { m_tower = value; } }
    public Vector3 targetTransform {  get { return m_targetTransform; } set { m_targetTransform = value; } }

    private void Awake()
    {
        if (m_tower != null)
            m_targetTransform = m_tower.transform.forward;

        StartCoroutine(FadeOut());
    }

    private void FixedUpdate()
    {
        //�Ѿ� ������ ����
        if (m_tower != null)
            transform.position += m_targetTransform * m_speed * Time.deltaTime;
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        // �浹�� ���� ������Ʈ�� ���Ͷ��
        if (collision.gameObject.CompareTag("Monster"))
        {
            // ���� ��ü�� TakeDamage �޼��带 ȣ���Ͽ� ���ظ� �����ϴ�.
            collision.gameObject.GetComponent<Monster>().TakeDamage(this);
        }

        // �Ѿ� �ڽ��� �ı��մϴ�.
        Destroy(gameObject);
    }
}
