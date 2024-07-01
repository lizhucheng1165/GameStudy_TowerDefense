using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
