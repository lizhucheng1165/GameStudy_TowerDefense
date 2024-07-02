using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] InGameManager currentInGameManager;
    [SerializeField] Text textCurrentGold;
    [SerializeField] Text textLeftEnemy;
    [SerializeField] Text textLifeCapacity;
    [SerializeField] Text textEnemyKilled;
    [SerializeField] Text textCurrentWave;
    [SerializeField] Text textDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        initGameStatusText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initGameStatusText()
    {
        textCurrentGold.text = 0.ToString();
        textLeftEnemy.text = 0.ToString();
        textLifeCapacity.text = 0.ToString();
        textEnemyKilled.text = 0.ToString();
        textCurrentWave.text = 0.ToString();
        textDifficulty.text = 0.ToString();
    }

    public void updateCurrentGoldStat()
    {
        textCurrentGold.text = currentInGameManager.getCurrentGold().ToString();
    }
}
