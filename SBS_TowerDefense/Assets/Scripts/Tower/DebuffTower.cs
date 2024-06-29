using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DebuffTower : Tower , InterFaces.IDeBuffAble
{
    public int effectRange { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float debuffDuration { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public GameObject[] FindEnemiesInRange(GameObject[] enemiesInRange)
    {
        throw new System.NotImplementedException();
    }

    public void GiveDebuff(GameObject[] enemies, int debuffDuration)
    {
        throw new System.NotImplementedException();
    }
    
}
