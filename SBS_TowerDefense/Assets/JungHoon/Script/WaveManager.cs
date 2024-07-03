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
    float fWaveStartDelayTime;
    float fTime;
    bool bWaveActive;
    int nTotalEnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        nCurrentWave = 0;
        nEnemyGeneratingCount = 0;
        nCurrentWaveMaxEnemyCount = 0;
        nLastWave = 3;
        fWaveStartDelayTime = 0f;
        fTime = 0f;
        bWaveActive = true;
        nTotalEnemyCount = 0;

        initGameWaveInfo(nLastWave);

        fWaveStartDelayTime = arGameWaveList[nCurrentWave].fWaveStartDelaySecond;

        //startWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(bWaveActive == true)
        {
            fTime += Time.deltaTime;
        }
        
        if(fTime >= fWaveStartDelayTime)
        {
            startWave();
            fWaveStartDelayTime = calculateNextWaveDelaySecond();
            fTime = 0f;
        }
        //Debug.Log(fTime.ToString());
    }

    float calculateNextWaveDelaySecond()
    {
        if(nCurrentWave >= nLastWave)
        {
            bWaveActive = false;
            return 99;
        }

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

        InvokeRepeating("generateEnemy", 0.5f, 1.0f);
    }

    void generateEnemy()
    {

        GameObject testEnemy = Instantiate(prefabEnemy);
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

    public void initGameWaveInfo(int nLastWaveCount)
    {
        int nWaveCount = 0;
        float fBufferTime = 5.0f;
        while (nWaveCount < nLastWaveCount)
        {
            Wave newWave = new Wave();
            newWave.nMyWaveNumber = nWaveCount;
            newWave.nCreateEnemyCount = 2;
            nTotalEnemyCount += newWave.nCreateEnemyCount;
            newWave.fWaveStartDelaySecond = fBufferTime;
            arGameWaveList.Add(newWave);
            nWaveCount++;
        }
        //Debug.Log("totalEnemyCount: " + nTotalEnemyCount);
        currentGameManager.setMaxEnemyCount(nTotalEnemyCount);
    }

}
