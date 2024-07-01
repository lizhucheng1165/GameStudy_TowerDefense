using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    [SerializeField] private int m_bulletEffectId;
    [SerializeField] private string m_bulletEffectName;
    [SerializeField] private string m_description;
    [SerializeField] private int m_staticDamage;
    [SerializeField] private float m_damageMutiplier;
    [SerializeField] private float m_staticRpm;
    [SerializeField] private float m_rpmMultiplier;
    [SerializeField] private float m_decreaseMinRangeMultiplier;
    [SerializeField] private float m_increaseMaxRangeMultiplier;
    [SerializeField] private bool m_trueControlable;
    [SerializeField] private float m_staticBulletSpeed;
    [SerializeField] private float m_bulletSpeedMultiplier;
    [SerializeField] private float m_staticCriticalChance;
    [SerializeField] private float m_criticalChanceMultiplier;
    [SerializeField] private float m_staticCriticalDamage;
    [SerializeField] private float m_criticalDamageMultiplier;
    [SerializeField] private float m_staticPenetration;
    [SerializeField] private float m_penetrationMultiplier;
    [SerializeField] private float m_staticPenetrationMultiplier;

    public int bulletEffectId { get { return m_bulletEffectId; } set { m_bulletEffectId = value; } }
    public string bulletEffectName { get { return m_bulletEffectName; } set { m_bulletEffectName = value; } }
    public string description { get { return m_description; } set { m_description = value; } }
    public int staticDamage { get { return m_staticDamage; } set { m_staticDamage = value; } }
    public float damageMultiplier { get { return m_damageMutiplier; } set { m_damageMutiplier = value; } }
    public float staticRpm { get { return m_staticRpm; } set { m_staticRpm = value; } }
    public float rpmMultiplier { get { return m_rpmMultiplier; } set { m_rpmMultiplier = value; } }
    public float decreaseMinRangeMultiplier { get { return m_decreaseMinRangeMultiplier; } set { m_decreaseMinRangeMultiplier = value; } }
    public float increaseMaxRangeMultiplier { get { return m_increaseMaxRangeMultiplier; } set { m_increaseMaxRangeMultiplier = value; } }
    public bool trueControlable { get { return m_trueControlable; } set { m_trueControlable = value; } }
    public float staticBulletSpeed { get { return m_staticBulletSpeed; } set { m_staticBulletSpeed = value; } }
    public float bulletSpeedMultiplier { get { return m_bulletSpeedMultiplier; } set { m_bulletSpeedMultiplier = value; } }
    public float staticCriticalChance { get { return m_staticCriticalChance; } set { m_staticCriticalChance = value; } }
    public float criticalChanceMultiplier { get { return m_criticalChanceMultiplier; } set { m_criticalChanceMultiplier = value; } }
    public float staticCriticalDamage { get { return m_staticCriticalDamage; } set { m_staticCriticalDamage = value; } }
    public float criticalDamageMultiplier { get { return m_criticalDamageMultiplier; } set { m_criticalDamageMultiplier = value; } }
    public float staticPenetration { get { return m_staticPenetration; } set { m_staticPenetration = value; } }
    public float penetrationMultiplier { get { return m_penetrationMultiplier; } set { m_penetrationMultiplier = value; } }
    public float staticPenetrationMultiplier { get { return m_staticPenetrationMultiplier; } set { m_staticPenetrationMultiplier = value; } }
   
    void Start()
    {

    }

    void Update()
    {

    }
}
