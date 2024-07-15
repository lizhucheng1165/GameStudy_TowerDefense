using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    private Animator animator;
    [SerializeField] protected float speed = 10f;
    protected Transform target;
    protected int waypointIndex = 0;
    public float rotationSpeed = 5f; 
    void Start()
    {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (target == null) return;

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (dir != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            lookRotation *= Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() {
        if(waypointIndex < 3) waypointIndex++;
        else waypointIndex = 0;
        target = Waypoints.points[waypointIndex];
    }
}
