using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : Tower , InterFaces.IAttackAble
{
    public float attackPower { get; set; }
    public int attackSpeed { get; set; }
    public int attackRange { get; set; }
    public GameObject[] enemiesInRage;
    public GameObject currentTargetEnemy;

    private void Awake()
    {

    }

    private void Update()
    {
        LookAtCurrentTargetEnemy();
    }
    public GameObject FindClosestEnemy(GameObject[] enemiesInRange)
    {
        if (enemiesInRage.Length != 0)
        {
            GameObject closestEnemy = enemiesInRage[0];
            foreach (GameObject enemy in enemiesInRage)
            {
                closestEnemy = CheckDistance(closestEnemy, enemy);
            }
            return closestEnemy;
        }
        return null;
    }

    public GameObject CheckDistance(GameObject currentClosestEnemy, GameObject srcEnemy)
    {
        float curretClosestDistance = Vector3.Distance(this.transform.position, currentClosestEnemy.transform.position);
        float srcEnemyDistance = Vector3.Distance(this.transform.position, srcEnemy.transform.position);

        if (curretClosestDistance > srcEnemyDistance)
        {
            return srcEnemy;
        }
        return currentClosestEnemy;
    }

    public GameObject[] FindEnemiesInRange(GameObject[] enemiesInRange, LayerMask mask)
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, attackRange, mask);
        enemiesInRage = new GameObject[colliders.Length];
        for (int i = 0; i < colliders.Length; i++)
        {
            enemiesInRage[i] = colliders[i].gameObject;
        }
        return enemiesInRage;
    }

    public void LookAtTarget(GameObject target)
    {
        if (target != null)
        {
            //Vector3 targetpoint = new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z);
            //transform.LookAt(targetpoint);
            transform.LookAt(target.transform);
        }
        else
        {
            Vector3 defaltDirection = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + Vector3.forward;
            transform.LookAt(defaltDirection);
        }
    }

    public void ShootProjectile()
    {
        throw new System.NotImplementedException();
    }

    public void CheckOutOfRange(GameObject currentTarget)
    {
        float currentDistance = Vector3.Distance(currentTarget.transform.position, this.transform.position);
        if ( currentDistance > attackRange)
        {
            currentTargetEnemy = null;
        }
    }

    public void LookAtCurrentTargetEnemy()
    {
        if (currentTargetEnemy != null)
        {
            CheckOutOfRange(currentTargetEnemy);
        }
        GameObject[] currentEnemiesInRage = FindEnemiesInRange(enemiesInRage, mask);
        if (currentTargetEnemy == null)
        {
            currentTargetEnemy = FindClosestEnemy(currentEnemiesInRage);
        }


        LookAtTarget(currentTargetEnemy);

    }
}
