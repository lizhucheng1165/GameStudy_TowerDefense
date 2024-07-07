using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterFaces : MonoBehaviour
{
    public interface IBuffAble
    {
        int effectRange { get; set; }
        float buffValue_AttackPower { get; set; }
        float buffValue_AttackSpeed { get; set; }

        GameObject[] FindTowersInRange(GameObject[] towersInRange);
        void GiveBuff(GameObject[] targets);
        void RemoveBuff(GameObject[] targets);
    }
    
    public interface IDeBuffAble
    {
        int effectRange { get; set; }
        float debuffDuration {  get; set; }

        void GiveDebuff(GameObject[] enemies, int debuffDuration);
        GameObject[] FindEnemiesInRange(GameObject[] enemiesInRange);
    }

    public interface IAttackAble
    {
        int attackPower { get; set; }
        float attackSpeed { get; set; }
        int attackRange { get; set; }

        GameObject FindClosestEnemy(GameObject[] enemiesInRange);
        GameObject[] FindEnemiesInRange(GameObject[] enemiesInRange, LayerMask mask);
        void LookAtTarget(GameObject target);
        void ShootProjectile();
    }

    public interface IEnemy
    {
        int maxHealth { get; set; }
        int currentHealth { get; set; }
        float moveSpeed { get; set; }
        int lootGold { get; set; }
        GameObject[] wayPoints {get; set;}


        void InitializeStatus(int waveCount);
        GameObject SetMovePoint(GameObject[] movepoint);
        void MoveToPoint(GameObject movePoint);
        void GiveMoney(int lootGold);
    }
}