using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalEnemy : Enemy
{
    private void Awake()
    {
        GetWayPointsList();
        wayPointIndexSrc = 0;
        moveSpeed = 1;
        maxHealth = 30;
        currentHealth = maxHealth;
        lootGold = 5;
    }
    private void Update()
    {
        MoveArround();
    }

}
