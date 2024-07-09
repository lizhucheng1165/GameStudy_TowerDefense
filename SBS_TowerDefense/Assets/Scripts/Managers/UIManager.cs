using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Text moneyText;
    public Text enemyCountText;
    public Text cancleText;
    public Text[] towerInfos;
    public GameObject HPBarPrefab;
    public List<Transform> enemyList = new List<Transform>();
    public List<GameObject> HPBarList = new List<GameObject>();
    public Transform HpBarCanvas;

    Camera mainCamera;
    protected override void Awake()
    {
        base.Awake();
        UIManagerInit();
    }

    private void Update()
    {
        ShowHpBar();
    }

    public void UIManagerInit()
    {
        GameObject.Find("MoneyText").TryGetComponent<Text>(out moneyText);
        GameObject.Find("EnemyCountText").TryGetComponent<Text>(out enemyCountText);
        GameObject.Find("CancleText").TryGetComponent<Text>(out cancleText);
        mainCamera = Camera.main;
    }
    public void SetMoneyUI()
    {
        moneyText.text = GameManager.Instance.Money.ToString();
    }

    public void SetEnemyCountText()
    {
        enemyCountText.text = GameManager.Instance.EnemyCount.ToString();
    }

    public void SetUpTowerSpawnCancleUI()
    {
        cancleText.enabled = !cancleText.enabled;
    }

    public void ShowTowerInfo(string towerName, int towerPrice, string towerDescription)
    {
        towerInfos[0].text = towerName;
        towerInfos[1].text = towerPrice.ToString();
        towerInfos[2].text = towerDescription;
    }

    private void ShowHpBar()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            HPBarList[i].transform.position = mainCamera.WorldToScreenPoint(enemyList[i].position + new Vector3(0, 0.5f, 0));
        }
    }
}
