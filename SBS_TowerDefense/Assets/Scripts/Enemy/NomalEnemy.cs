using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalEnemy : Enemy
{
    private void Awake()
    {
        GetWayPointsList();
        foreach (GameObject test in wayPoints)
        {
            print(test.name);
        }
    }
    private void Update()
    {
        MoveToPoint(SetMovePoint(wayPoints));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            wayPointIndexSrc++;
        }
    }

}
