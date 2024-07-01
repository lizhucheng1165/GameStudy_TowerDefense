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

    public int bulletId { get { return m_bulletId; } set { m_bulletId = value; } }
    public float damage { get { return m_damage; } set { m_damage = value; } }
    public float speed { get { return m_speed; } set { m_speed = value; } }
    public float penetration { get { return m_penetration; } set {m_penetration = value; } }
    public float penetrationMultiplier { get { return m_penetrationMultiplier; } set { m_penetrationMultiplier = value; } }
    public float critcalChance { get { return m_critcalChance; } set { m_critcalChance = value; } }
    public float criticalDamageMultiplier { get { return m_criticalDamageMultiplier; } set { m_criticalDamageMultiplier = value; } }
    public List<BulletEffect> bulletEffects { get { return m_bulletEffects; } set { m_bulletEffects = value; } }
}
