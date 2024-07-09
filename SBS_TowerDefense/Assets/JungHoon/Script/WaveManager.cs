using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] InGameManager currentGameManager;
    [SerializeField] UIManager currentUIManager;
    public List<Wave> arGameWaveList = new List<Wave>();
    [SerializeField] GameObject prefabEnemy;
    int nEnemyGeneratingCount;
    int nCurrentWave;
    int nCurrentWaveMaxEnemyCount;
    int nLastWave;
    float fWaveStartTime;
    float fWaveDelayTime;
    float fWaveStartCountDown;
    int nWaveStartCountDown;
    bool bWaveActive;
    int nTotalEnemyCount;
    bool bNextWaveAlert;

    // Start is called before the first frame update
    void Start()
    {

        initWaveManager(3);

        if(initGameWaveInfo(nLastWave, 5.0f))
        {
            Debug.Log("initGameWaveInfo success..");
        }
        else
        {
            Debug.Log("initGameWaveInfo failed..");
        }

        //fWaveStartDelayTime = arGameWaveList[nCurrentWave].fWaveStartDelaySecond;
        fWaveStartTime = calculateNextWaveDelaySecond();
        //startWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(bWaveActive == true)
        {
            fWaveDelayTime += Time.deltaTime;
            fWaveStartCountDown = fWaveStartTime - fWaveDelayTime;
            nWaveStartCountDown = (int)fWaveStartCountDown;
            nWaveStartCountDown++;
            currentUIManager.textDelayTimeToNextWave.text = nWaveStartCountDown.ToString();
        }

        if(nWaveStartCountDown <= 3 && bNextWaveAlert == false)
        {
            bNextWaveAlert = true;
            currentUIManager.panelDelayTimeToNextWave.SetActive(true);
        }

        if (fWaveDelayTime >= fWaveStartTime)
        {
            startWave();
            fWaveStartTime = calculateNextWaveDelaySecond();
            fWaveDelayTime = 0f;
        }
        //Debug.Log(fTime.ToString());
    }

    void initWaveManager(int nMaxWave)
    {
        nCurrentWave = 0;
        nEnemyGeneratingCount = 0;
        nCurrentWaveMaxEnemyCount = 0;
        nLastWave = nMaxWave;
        fWaveStartTime = 0f;
        fWaveDelayTime = 0f;
        bWaveActive = true;
        nTotalEnemyCount = 0;
        bNextWaveAlert = false;
    }

    float calculateNextWaveDelaySecond()
    {
        if(nCurrentWave >= nLastWave)
        {
            bWaveActive = false;
            currentUIManager.panelDelayTimeToNextWave.SetActive(false);
            return 99;
        }

        bNextWaveAlert = false;
        currentUIManager.panelDelayTimeToNextWave.SetActive(false);
        return arGameWaveList[nCurrentWave].fWaveStartDelaySecond;
    }

    public int getCurrentWaverNumber()
    {
        return nCurrentWave;
    }

    public void startWave()
    {
        //currentGameManager.nCurrentWave++;
        //currentGameManager.addCurrentWaveNumber();
        nCurrentWave++;
        currentUIManager.updateCurrentWave();
        //currentUIManager.textCurrentWave.text = nCurrentWave.ToString();

        int nWaveListIndex;

        //nWaveListIndex = currentGameManager.getCurrentWaveNumber() - 1;
        nWaveListIndex = nCurrentWave - 1;

        nCurrentWaveMaxEnemyCount = arGameWaveList[nWaveListIndex].nCreateEnemyCount;
        //currentGameManager.setMaxEnemyCount(nCurrentWaveMaxEnemyCount);

        InvokeRepeating("generateEnemy", 0.5f, 0.5f);
    }

    void generateEnemy()
    {

        GameObject testEnemy = Instantiate(prefabEnemy);
        testEnemy.name += nEnemyGeneratingCount.ToString();
        testEnemy.transform.position = new Vector3(-30.0f, 30.0f, -2.0f);
        nEnemyGeneratingCount++;
       // nTotalEnemyCount++;
        currentGameManager.addLeftEnemyCount();
        //int nWaveListIndex = currentGameManager.getCurrentWaveNumber() - 1;
        //int nTempMaxEnemyCount = arGameWaveList[nWaveListIndex].nCreateEnemyCount;
        if (nEnemyGeneratingCount >= nCurrentWaveMaxEnemyCount)
        {
            CancelInvoke("generateEnemy");
            nEnemyGeneratingCount = 0;
        }

    }

    public bool initGameWaveInfo(int nLastWaveCount, float fStartDelayTime)
    {
        int nWaveCount = 0;
        //float fBufferTime = 5.0f;
        while (nWaveCount < nLastWaveCount)
        {
            Wave newWave = new Wave();
            newWave.nMyWaveNumber = nWaveCount;
            newWave.nCreateEnemyCount = 2;
            nTotalEnemyCount += newWave.nCreateEnemyCount;
            //newWave.fWaveStartDelaySecond = fBufferTime;
            newWave.fWaveStartDelaySecond = fStartDelayTime;
            arGameWaveList.Add(newWave);
            nWaveCount++;
        }
        //Debug.Log("totalEnemyCount: " + nTotalEnemyCount);
        currentGameManager.setMaxEnemyCount(nTotalEnemyCount);

        if(fStartDelayTime <= 3)
        {
            return false;
        }

        return true;
    }

}
