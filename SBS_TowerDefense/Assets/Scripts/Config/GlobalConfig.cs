using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GlobalConfig", menuName = "ScriptableObjects/GlobalConfig", order = 1)]

public class GlobalConfig : ScriptableObject
{
    [SerializeField] private float m_breakTimeLength;
    [SerializeField] private float m_waveTimeLength;
    [SerializeField] private float m_finalBossTimeLength;
    [SerializeField] private float m_finalBossBaseHealth;
    [SerializeField] private int m_startMoney;

    public float breakTimeLength {  get { return m_breakTimeLength; } }
    public float waveTimeLength {  get { return m_waveTimeLength; } }
    public float finalBossTimeLength {  get { return m_finalBossTimeLength; } }
    public float finalBossBaseHealth {  get { return m_finalBossBaseHealth; } }
    public int startMoney {  get { return m_startMoney; } }
}
