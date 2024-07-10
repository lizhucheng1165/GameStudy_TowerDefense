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

    private void OnEnable()
    {
        KillAllExistingEnemies();
    }

    void AddTotalHelth(int currentHealth)
    {
        maxHealth += currentHealth;
    }

    void KillAllExistingEnemies()
    {
        //foreach (Transform item in UIManager.Instance.enemyList)
        //{
        //    if (!item.TryGetComponent<BossEnemy>(out BossEnemy boss))
        //    {
        //        UIManager.Instance.enemyList.Remove(item);
        //        Destroy(item.gameObject);
        //    }
        //}
        //foreach (GameObject item in UIManager.Instance.HPBarList)
        //{
        //    if (!item.TryGetComponent<BossEnemy>(out BossEnemy boss))
        //    {
        //        UIManager.Instance.HPBarList.Remove(item);
        //        Destroy(item);
        //    }
        //}
    }
}
