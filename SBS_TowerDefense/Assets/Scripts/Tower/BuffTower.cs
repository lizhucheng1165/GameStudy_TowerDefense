using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffTower : Tower, InterFaces.IBuffAble
{
    public int effectRange { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float buffValue_AttackPower { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float buffValue_AttackSpeed { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public virtual GameObject[] FindTowersInRange(GameObject[] towersInRange)
    {
        throw new System.NotImplementedException();
    }

    public virtual void GiveBuff(GameObject[] targets)
    {
        throw new System.NotImplementedException();
    }

    public virtual void RemoveBuff(GameObject[] targets)
    {
        throw new System.NotImplementedException();
    }

   
}
