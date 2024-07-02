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
}
