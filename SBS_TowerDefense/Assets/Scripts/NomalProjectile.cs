using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalProjectile : Projectile
{
    private void Awake()
    {
        projectileDamage = 20;//추후 2로 변경
        projectileSpeed = 1f;
    }
}
