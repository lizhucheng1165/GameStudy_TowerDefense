using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerConfig", menuName = "ScriptableObjects/TowerConfig", order = 1)]
public class TowerConfig : ScriptableObject
{
    [SerializeField] private List<Tower> m_towers;

    public List<Tower> towers {  get { return m_towers; } set { m_towers = value; } }
}
