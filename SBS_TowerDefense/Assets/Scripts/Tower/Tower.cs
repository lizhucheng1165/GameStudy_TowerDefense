using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType { NOMAL, CHAIN, SNIPER, POWERBUFF, SLOW}

public abstract class Tower : MonoBehaviour
{
    int price;
    int level;
    bool UpgradeAble;
    TowerType towerType;
    int usedMoneyToUpgrade;
    
    public virtual void InitializeStatus(TowerType type)
    {

    }
    public virtual void Upgrade(int level)
    {

    } 
    public virtual void SellTower(int usedMoneyToUpgrade)
    {

    }

}
