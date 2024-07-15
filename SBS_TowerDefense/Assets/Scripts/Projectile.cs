using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    private float speed = 80f;
    private float damage = 5f;
    [SerializeField] private GameObject impactEffect;
    public void LockTarget(Transform currentTarget)
    {
        target = currentTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        if(direction.magnitude <= distance)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distance, Space.World);
    }

    void HitTarget() 
    {
        GameObject effectInstance = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);
        Destroy(gameObject);
        DealDamage(target);
    }

    void DealDamage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if(e != null)
        {
            e.TakeDamage(damage);
        }
    }
}
