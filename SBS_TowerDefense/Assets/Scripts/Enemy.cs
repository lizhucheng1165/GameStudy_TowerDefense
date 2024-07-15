using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float speed = 10f;
    protected Transform target;
    protected int waypointIndex = 0;
    protected float healthPoint = 10f;
    protected int bounty = 50;
    protected virtual void Start()
    {
        target = Waypoints.points[0];
    }
    
    void Update()
    {
       
    }

    void GetNextWaypoint() {
        if(waypointIndex < 3) waypointIndex++;
        else waypointIndex = 0;
        target = Waypoints.points[waypointIndex];
    }

    public void TakeDamage(float damage)
    {
        healthPoint -= damage;
        Debug.Log("Damage Taken");
        if(healthPoint <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
        WaveManager.DecreaseEnemyCount();
        Debug.Log("Enemy Killed");
        Resources.AddMoney(bounty);
    }
}
