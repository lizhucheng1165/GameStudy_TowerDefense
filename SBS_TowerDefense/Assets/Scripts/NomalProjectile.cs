using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalProjectile : Projectile
{
    private void Awake()
    {
        projectileDamage = 20;//���� 2�� ����
        projectileSpeed = 1f;
    }
}
