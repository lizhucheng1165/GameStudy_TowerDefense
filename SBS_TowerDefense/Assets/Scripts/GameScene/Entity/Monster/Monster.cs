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

    private Transform[] waypoints;
    private int currentWaypoint = 0;

    private void Awake()
    {
        waypoints = new Transform[4];
        for (int i = 0; i < 4; i++)
        {
            waypoints[i] = GameObject.Find("Waypoint_"+i).transform;
        }
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
}
