using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Text moneyText;
    public Text enemyCountText;
    public Text cancleText;
    protected override void Awake()
    {
        base.Awake();
        GameObject.Find("MoneyText").TryGetComponent<Text>(out moneyText);
        GameObject.Find("EnemyCountText").TryGetComponent<Text>(out enemyCountText);
        GameObject.Find("CancleText").TryGetComponent<Text>(out cancleText);
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
}
