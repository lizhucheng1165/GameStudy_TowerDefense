using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/Create TowerData")]
public class TowerData : ScriptableObject
{
    [SerializeField]
    private int price;
    public int Price { get { return price; } }
    [SerializeField]
    private int level;
    public int Level { get { return level; } }
    [SerializeField]
    private bool upgradeAble;
    public bool UpgradeAble { get { return upgradeAble; } }
    [SerializeField]
    private TowerType towerType;
    public TowerType TowerType { get { return towerType; } }
    [SerializeField]
    private string towerDescription;
    public string TowerDescription { get { return towerDescription; } }

}
