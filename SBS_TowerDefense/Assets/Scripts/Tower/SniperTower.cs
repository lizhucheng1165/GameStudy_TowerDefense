using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperTower : AttackTower
{
    private void Awake()
    {
        attackPower = 10;
        price = 50;
        attackRange = 5;
        attackSpeed = 2;
        towerType = TowerType.SNIPER;
        upgradeAble = true;
        elapsedTimeSinceLastFire = 0;
    }
}
