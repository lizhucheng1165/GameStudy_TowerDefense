using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MonsterModifierConfig", menuName = "ScriptableObjects/MonsterModifierConfig", order = 1)]
public class MonsterModifierConfig : ScriptableObject
{
    [SerializeField] private List<MonsterModifier> m_monsterModifiers;
}
