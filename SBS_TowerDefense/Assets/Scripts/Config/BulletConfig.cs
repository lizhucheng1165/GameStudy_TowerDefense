using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "ScriptableObjects/BulletConfig", order = 1)]

public class BulletConfig : ScriptableObject
{
    [SerializeField] private List<Bullet> m_bullets;
}
