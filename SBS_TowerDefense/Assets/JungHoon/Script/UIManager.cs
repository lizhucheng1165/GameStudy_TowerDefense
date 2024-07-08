using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] InGameManager currentInGameManager;
    [SerializeField] WaveManager currentWaveManager;
    [SerializeField] Text textCurrentGold;
    [SerializeField] Text textLeftEnemy;
    [SerializeField] Text textLifeCapacity;
    [SerializeField] Text textEnemyKilled;
    [SerializeField] Text textCurrentWave;
    [SerializeField] Text textLastWave;
    public Text textDelayTimeToNextWave;
    public GameObject panelDelayTimeToNextWave;

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
        textCurrentWave.text = currentWaveManager.getCurrentWaverNumber().ToString();
        textLastWave.text = currentInGameManager.getLastWave().ToString();
    }

    public void updateCurrentGoldStat()
    {
        textCurrentGold.text = currentInGameManager.getCurrentGold().ToString();
    }

    public void updateCurrentEnemyKilled()
    {
        textEnemyKilled.text = currentInGameManager.getCurrentEnemyKilled().ToString();
    }

    public void updateCurrentLeftEnemy()
    {
        textLeftEnemy.text = currentInGameManager.getCurrentLeftEnemy().ToString();
    }

    public void updateCurrentWave()
    {
        //textCurrentWave.text = currentInGameManager.getCurrentWaveNumber().ToString();
        //Debug.Log("wave num:" + currentWaveManager.getCurrentWaverNumber().ToString());
        textCurrentWave.text = currentWaveManager.getCurrentWaverNumber().ToString();
    }
    
    public void updateLastWave()
    {
        textLastWave.text = currentInGameManager.getLastWave().ToString();
    }

}
