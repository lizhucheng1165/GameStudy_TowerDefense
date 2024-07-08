using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed { get; set; }
    public int projectileDamage { get; set; }
    public GameObject currentTarget { get; set; }
    public int towerDamage;

    private void Start()
    {
        MoveTowardsCurrentTarget();
    }
    public void MoveTowardsCurrentTarget()
    {
        while (CheckDistanceToCurrentTarget())
        {
            Vector3 direction = Vector3.MoveTowards(this.transform.position, currentTarget.transform.position, projectileSpeed * Time.deltaTime);
            this.transform.position = direction;
        }
        
    }

    public bool CheckDistanceToCurrentTarget()
    {
        if (currentTarget != null)
        {
            float currentTargetDistance = Vector3.Distance(this.transform.position, currentTarget.transform.position);
            if (currentTargetDistance > 0)
            {
                return true;
            }
        }

        return false;
    }

    public void SetCurrentTarget(GameObject target)
    {
        currentTarget = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(projectileDamage, towerDamage);
            }

            Destroy(this.gameObject);
        }
    }
    public void SetTowerDamage(int towerDamage)
    {
        this.towerDamage = towerDamage;
    }
}
