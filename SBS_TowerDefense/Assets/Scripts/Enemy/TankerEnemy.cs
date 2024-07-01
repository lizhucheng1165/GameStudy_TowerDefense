using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerEnemy : Enemy
{
    private void Awake()
    {
        GetWayPointsList();
        wayPointIndexSrc = 0;
        moveSpeed = 0.3f;
        maxHealth = 50;
        currentHealth = maxHealth;
        lootGold = 10;
    }
    private void Update()
    {
        MoveArround();
    }

}
