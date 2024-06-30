using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 10f;
    private Transform target;
    private int waypointIndex = 0;
    void Start()
    {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextWaypoint();
        }

    }

    void GetNextWaypoint() {
        if(waypointIndex < 3) waypointIndex++;
        else waypointIndex = 0;
        target = Waypoints.points[waypointIndex];
    }
}
