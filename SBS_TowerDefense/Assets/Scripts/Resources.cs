using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    void Start()
    {
        moneyText.gameObject.SetActive(true);
    }
    void Update()
    {
        moneyText.text = "Money: $"+ playerMoney.ToString();
    }
    public static int playerMoney = 100;

    public static void AddMoney(int amount)
    {
        playerMoney += amount;
    }

    public static void SpendMoney(int amount)
    {
        playerMoney -= amount;
    }
    
}
