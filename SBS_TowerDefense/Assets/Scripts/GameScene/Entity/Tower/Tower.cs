using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
