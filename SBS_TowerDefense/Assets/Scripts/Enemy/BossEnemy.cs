using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    public float timeToDefeat = 30;
    public float TimeToDefeat 
    {
        get
        { 
            return timeToDefeat; 
        }
        set 
        {
            timeToDefeat = value;
            UIManager.Instance.ShowRemainingTimeToDefeat(timeToDefeat); 
        }
    }


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
        UIManager.Instance.timeToDefeatText.gameObject.SetActive(true);
        StartCoroutine(CheckTimeUntilDefeat());
    }

    void AddTotalHelth(int currentHealth)
    {
        maxHealth += currentHealth;
    }

    void KillAllExistingEnemies()
    {
        foreach (Transform item in new List<Transform>(UIManager.Instance.enemyList))
        {
            if (!item.TryGetComponent<BossEnemy>(out BossEnemy boss))
            {
                UIManager.Instance.enemyList.Remove(item);
                Destroy(item.gameObject);
            }
        }

        foreach (GameObject item in new List<GameObject>(UIManager.Instance.HPBarList))
        {
            if (!item.TryGetComponent<BossEnemy>(out BossEnemy boss))
            {
                UIManager.Instance.HPBarList.Remove(item);
                Destroy(item);
            }
        }
    }

    private void OnDestroy()
    {
        if (GameManager.Instance.currentGameState == GameState.PLAYING)
        {
            GameManager.Instance.GameWin();
        }
    }

    IEnumerator CheckTimeUntilDefeat()
    {
        while (true)
        {
            TimeToDefeat -= Time.deltaTime;
            if (TimeToDefeat < 0)
            {
                GameManager.Instance.GameLose();
                yield break;
            }

            yield return null;
        }
    }
}
