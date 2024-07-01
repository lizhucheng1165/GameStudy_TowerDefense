using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletEffectConfig", menuName = "ScriptableObjects/BulletEffectConfig", order = 1)]
public class BulletEffectConfig : ScriptableObject
{
    [SerializeField] private List<BulletEffect> m_bulletEffects;
}
