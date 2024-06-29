using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackTower : Tower , InterFaces.IAttackAble
{
    public float attackPower { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int attackSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int attackRange { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public GameObject FindClosestEnemy(GameObject[] enemiesInRange)
    {
        throw new System.NotImplementedException();
    }

    public GameObject[] FindEnemiesInRange(GameObject[] enemiesInRange)
    {
        throw new System.NotImplementedException();
    }

    public void LookAtTarget(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public void ShootProjectile()
    {
        throw new System.NotImplementedException();
    }

}
