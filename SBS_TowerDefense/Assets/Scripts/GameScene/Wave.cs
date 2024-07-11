using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] int m_id;
    [SerializeField] int m_waveNumber;
    [SerializeField] int m_spawnCount;
    [SerializeField] int m_spawnMonsterId;
    [SerializeField] float m_spawnInterval;

    public int id {  get { return m_id; } } 
    public int waveNumber { get { return m_waveNumber; } set { m_waveNumber = value; } }
    public int spawnMonsterId { get { return m_spawnMonsterId; } set { m_spawnMonsterId = value; } }
    public int spawnCount { get { return m_spawnCount; } set { { m_spawnCount = value; } } }
    public float spawnInterval { get { return m_spawnInterval; } set { { m_spawnInterval = value; } } }
}
