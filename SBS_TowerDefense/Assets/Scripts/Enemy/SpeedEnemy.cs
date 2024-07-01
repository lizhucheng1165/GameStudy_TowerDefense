using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEnemy : Enemy
{
    private void Awake()
    {
        GetWayPointsList();
        wayPointIndexSrc = 0;
        moveSpeed = 3f;
        maxHealth = 20;
        currentHealth = maxHealth;
        lootGold = 7;
    }
    private void Update()
    {
        MoveArround();
    }
}
