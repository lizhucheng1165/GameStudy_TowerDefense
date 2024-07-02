using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MonsterConfig", menuName = "ScriptableObjects/MonsterConfig", order = 1)]
public class MonsterConfig : ScriptableObject
{
    [SerializeField] private List<Monster> m_monsters;
    public List<Monster> monsters { get { return m_monsters; } }
}
