using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType { NOMAL, SNIPER, CHAIN, POWERBUFF, SLOW}

public class Tower : MonoBehaviour
{
    public int price { get; set; }
    public int level { get; set; }
    public bool upgradeAble { get; set; }
    public TowerType towerType { get; set; }
    public int usedMoneyToUpgrade { get; set; }
    public LayerMask mask;

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
