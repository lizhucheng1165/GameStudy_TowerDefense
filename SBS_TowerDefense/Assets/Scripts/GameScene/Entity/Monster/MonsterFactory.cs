using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MonsterFactory
{
    private List<Monster> monsters;

    public MonsterFactory()
    {
        monsters = GameInstance.Instance.monsterConfig.monsters;
    }

    public Monster SpawnMonster(int monsterId)
    {
        Monster findMonster = null;
        foreach (Monster monster in monsters)
        {
            if (monster.monsterId == monsterId)
                findMonster = monster;
        }

        if (findMonster == null)
            return null;

        findMonster.transform.position = Vector3.zero + Vector3.up;
        return PrefabUtility.InstantiatePrefab(findMonster) as Monster;
    }

    public Monster SpawnFinalBoss(float health)
    {
        Monster finalBoss = null;
        foreach (Monster monster in monsters)
        {
            if (monster.monsterId == 1000)
                finalBoss = monster;
        }

        int difficulty = GameInstance.Instance.difficulty;

        finalBoss.currentHealth = health;
        finalBoss.maxHealth = health;
        finalBoss.moveSpeed = 3+difficulty * 1;
        finalBoss.armor = difficulty * 5;
        finalBoss.damageReduceMultiplier = (float)difficulty * 0.05f;
        finalBoss.transform.position = Vector3.zero + Vector3.up;

        GameInstance.Instance.gameManager.GetComponent<GameManager>().spawnedMonsters.Add(finalBoss);

        return PrefabUtility.InstantiatePrefab(finalBoss) as Monster;
    }
}
