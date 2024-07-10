using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    private void Awake()
    {
        GetWayPointsList();
        wayPointIndexSrc = 0;
        moveSpeed = 0.8f;
        maxHealth = 1000;
        AddTotalHelth(GameManager.Instance.enemyTotalHealth);
        currentHealth = maxHealth;
        lootGold = 500;
    }
    private void Update()
    {
        MoveArround();
    }

    void AddTotalHelth(int currentHealth)
    {
        maxHealth += currentHealth;
    }
}
