using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalTower : AttackTower
{
    private void Awake()
    {
        attackPower = 2.0f;
        price = 5;
        attackRange = 3;
        attackSpeed = 1;
        towerType = TowerType.NOMAL;
        UpgradeAble = true;
    }
}
