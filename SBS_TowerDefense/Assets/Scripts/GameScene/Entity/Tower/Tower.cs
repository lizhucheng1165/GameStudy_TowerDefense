using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    [SerializeField] private int m_towerId;
    [SerializeField] private string m_towerName;
    [SerializeField] private string m_description;
    [SerializeField] private int m_type;
    [SerializeField] private int m_rating;
    [SerializeField] private float m_price;
    [SerializeField] private float m_rpm;
    [SerializeField] private float m_minRange;
    [SerializeField] private float m_maxRange;
    [SerializeField] private Enums.MonsterType m_priorityTarget;
    [SerializeField] private Enums.RangeType m_priorityTargetRange;
    [SerializeField] private List<Bullet> m_bulletList;
    [SerializeField] private float m_bulletAngle;
    [SerializeField] private bool isControllable;
    [SerializeField] private List<TowerModifier> m_modifiers;

    private GameObject m_minRangeIndicatorPrefab;
    private GameObject m_maxRangeIndicatorPrefab;

    private GameObject m_minRangeIndicatorInstance;
    private GameObject m_maxRangeIndicatorInstance;

    float firstDistance = 0;
    private Transform target;

    private bool isSelected;

    public int towerId { get { return m_towerId; } set { m_towerId = value; } }
    public string towerName { get { return m_towerName; } set { m_towerName = value; } }
    public string description { get { return m_description; } set { m_description = value; } }
    public int type { get { return m_type; } set { m_type = value; } }
    public int rating { get { return m_rating; } set { m_rating = value; } }
    public float price { get { return m_price; } set { m_price = value; } }
    public float rpm { get { return m_rpm; } set { m_rpm = value; } }
    public float minRange { get { return m_minRange; } set { m_minRange = value; } }
    public float maxRange { get { return m_maxRange; } set { m_maxRange = value; } }
    public Enums.MonsterType priorityTarget { get { return m_priorityTarget; } set { m_priorityTarget = value; } }
    public Enums.RangeType priorityTargetRange { get { return m_priorityTargetRange; } set { m_priorityTargetRange = value; } }
    public List<Bullet> bulletList { get { return m_bulletList; } set { m_bulletList = value; } }
    public float bulletAngle { get { return m_bulletAngle; } set { m_bulletAngle = value; } }
    public bool IsControllable { get { return isControllable; } set { isControllable = value; } }
    public List<TowerModifier> modifiers { get { return m_modifiers; } set { m_modifiers = value; } }

    private LineRenderer lineRenderer;


    public void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        m_minRangeIndicatorPrefab = Resources.Load<GameObject>("Prefabs/Towers/Indicators/MinRangeIndicator");
        m_maxRangeIndicatorPrefab = Resources.Load<GameObject>("Prefabs/Towers/Indicators/MaxRangeIndicator");

        m_minRangeIndicatorPrefab.tag = "Indicator";
        m_maxRangeIndicatorPrefab.tag = "Indicator";
    }

    IEnumerator fire()  //��Ƽ������
    {
        while (true)
        {
            if (target != null)
            {
                foreach (Bullet bullet in m_bulletList)
                {
                    Bullet spawnBullet = Instantiate<Bullet>(bullet, transform.position, transform.rotation);
                    spawnBullet.tower = this;
                    if (m_bulletList.Count == 1)
                        spawnBullet.targetTransform = this.transform.forward;
                    else if (m_bulletList.Count >= 2)
                    {
                        if (m_bulletAngle <= 0)
                            m_bulletAngle = 45;
                        float randomAngle = Random.Range(-m_bulletAngle / 2f, m_bulletAngle / 2f);
                        Quaternion randomRotation = Quaternion.AngleAxis(randomAngle, transform.up);

                        spawnBullet.targetTransform = randomRotation * transform.forward;
                    }
                }
                yield return new WaitForSeconds(1f / (m_rpm / 60f));
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    private bool FindTarget()
    {
        // �����Ÿ� ���� �ִ� ���͸� ã�´�
        Collider[] colliders =Physics.OverlapSphere(transform.position, m_maxRange);
        List<Collider> inRangeColliders = new List<Collider>();

        //��Ÿ� �� ���͸� ������
        foreach (Collider item in colliders)
        {
            if (item.CompareTag("Monster"))
            {
                float distance = Vector3.Distance(transform.position, item.transform.position);
                if (distance <= m_maxRange && distance > m_minRange)
                    inRangeColliders.Add(item);
            }
        }

        //����� �ϳ��� ���, ���°�� ó��
        if (inRangeColliders.Count <= 0)
        {
            target = null;
            return false;
        }
        else if (inRangeColliders.Count == 1)
        {
            target = inRangeColliders[0].transform;
            return false;
        }

        firstDistance = Vector3.Distance(transform.position, inRangeColliders[0].transform.position);

        if (target != null)
        {
            // ���� Ÿ���� ������ �����Ÿ� ���� �ִ��� Ȯ��
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance <= m_maxRange && distance > m_minRange)
                return true;
            else
            {
                target = null;
                firstDistance = 0f;
            }
        }

        //�켱����
        foreach (Collider item in inRangeColliders)
        {
            Monster monster = item.GetComponent<Monster>();
            float distance = Vector3.Distance(transform.position, item.transform.position);

            // �켱���� Ÿ�� Ÿ�԰� �����Ÿ��� �����ϴ� ��� target���� �����Ѵ�
            if (priorityTargetRange == Enums.RangeType.Short)
            {
                if (distance < firstDistance)
                {
                    firstDistance = distance;
                    target = item.transform;
                }
            }
            else if (priorityTargetRange == Enums.RangeType.Long)
            {
                if (distance > firstDistance)
                {
                    firstDistance = distance;
                    target = item.transform;
                }
            }
        }

        // �����Ÿ� ���� �켱���� Ÿ���� ������ target�� null�� �����Ѵ�
        if (firstDistance == 0)
        {
            target = null;
            return false;
        }

        return true;
    }

    private void LookAtTarget()
    {
        // Ÿ���� ���͸� ��� �Ĵٺ����� �Ѵ�
        if (target != null)
        {
            transform.LookAt(target);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, target.position);
        }
    }

    void Start()
    {
        StartCoroutine(fire());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        FindTarget();
        LookAtTarget();
    }

    private void OnMouseDown()
    {
        if (!isSelected)
        {
            m_maxRangeIndicatorInstance = Instantiate(m_maxRangeIndicatorPrefab, transform.position, Quaternion.identity);
            m_maxRangeIndicatorInstance.transform.localScale = new Vector3(m_maxRange * 2, 0.1f, m_maxRange * 2);
            m_maxRangeIndicatorInstance.transform.position = transform.position;        

            m_minRangeIndicatorInstance = Instantiate(m_minRangeIndicatorPrefab, transform.position, Quaternion.identity);
            m_minRangeIndicatorInstance.transform.localScale = new Vector3(m_minRange * 2, 0.1f, m_minRange * 2);
            m_minRangeIndicatorInstance.transform.position = transform.position;
            isSelected = true;
        }
        else
        {
            Destroy(m_maxRangeIndicatorInstance);
            Destroy(m_minRangeIndicatorInstance);
            isSelected = false;
        }
    }
}
