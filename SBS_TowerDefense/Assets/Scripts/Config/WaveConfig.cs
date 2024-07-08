using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WaveConfig", menuName = "ScriptableObjects/WaveConfig", order = 1)]

public class WaveConfig : ScriptableObject
{
    [SerializeField] private List<Wave> m_waves;

    public List<Wave> waves {  get { return m_waves; } }
}
