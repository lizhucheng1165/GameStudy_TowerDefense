using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TowerModifierConfig", menuName = "ScriptableObjects/TowerModifierConfig", order = 1)]

public class TowerModifierConfig : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] private List<TowerModifier> m_towerModiators;
}
