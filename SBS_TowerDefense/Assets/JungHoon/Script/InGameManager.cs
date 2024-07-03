using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameManager : MonoBehaviour
{
    public GameObject prefabTowerTile;
    public GameObject prefabEnemyPathTile;
    public GameObject prefabEnemy;
    [SerializeField] GameObject objectGameBoard;
    [SerializeField] UIManager currentUIManager;
    [SerializeField] WaveManager currentWaveManager;

    public List<GameObject> arrBoardTile = new List<GameObject>();
    //int nEnemyGeneratingCount;

    int nCurrentGold;
    int nEnemyKilled;
    int nLeftEnemy;
    int nMaxEnemyCount;
    int nCurrentWave;
    int nLastWave;

    //public List<Wave> arGameWaveList = new List<Wave>();

    // Start is called before the first frame update
    void Start()
    {
        initGameStatus();
        //currentWaveManager.initGameWaveInfo(nLastWave);
        generateBaseTile(7);
        //startWave();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCurrentGold()
    {
        return nCurrentGold;
    }

    public void minusCurrentGold(int nMinusGold)
    {
        nCurrentGold -= nMinusGold;
        currentUIManager.updateCurrentGoldStat();
    }

    public void addCurrentGold(int nAddValue)
    {
        nCurrentGold += nAddValue;
    }

    public void addEnemyKilled()
    {
        nEnemyKilled++;
        if(nEnemyKilled  == nMaxEnemyCount)
        {
            gotoResultScene();
        }
    }

    public void setMaxEnemyCount(int inputMaxEnemyCount)
    {
        nMaxEnemyCount = inputMaxEnemyCount;
        Debug.Log("nMaxEnemyCount: " + nMaxEnemyCount);
    }

    public int getMaxEnemyCount()
    {
        return nMaxEnemyCount;
    }

    public void addCurrentWaveNumber()
    {
        nCurrentWave++;
    }

    public int getCurrentWaveNumber()
    {
        return nCurrentWave;
    }

    public int getCurrentEnemyKilled()
    {
        return nEnemyKilled;
    }

    public int getCurrentLeftEnemy()
    {
        return nLeftEnemy;
    }

    public void addLeftEnemyCount()
    {
        nLeftEnemy++;
        currentUIManager.updateCurrentLeftEnemy();
    }

    public int getLastWave()
    {
        return nLastWave;
    }

    public void minusLeftEnemyCount()
    {
        nLeftEnemy--;
        currentUIManager.updateCurrentLeftEnemy();
    }

    void initGameStatus()
    {
        nCurrentGold = 30;
        //nEnemyGeneratingCount = 0;
        nEnemyKilled = 0;
        nLeftEnemy = 0;
        nMaxEnemyCount = 0;
        nCurrentWave = 0;
        nLastWave = 5;
    }

    //void initGameWaveInfo(int nLastWaveCount)
    //{
    //    int nWaveCount = 0;
    //    while (nWaveCount < nLastWaveCount)
    //    {
    //        Wave newWave = new Wave();
    //        newWave.nMyWaveNumber = nWaveCount;
    //        newWave.nCreateEnemyCount = 3;
    //        arGameWaveList.Add(newWave);
    //        nWaveCount++;
    //        Debug.Log(newWave.nMyWaveNumber + " newWave created and added..");
    //    }
    //}

    //public void startWave()
    //{
    //    nCurrentWave++;
    //    currentUIManager.updateCurrentWave();
        
    //    int nWaveListIndex;

    //    nWaveListIndex = nCurrentWave - 1;
    //    nMaxEnemyCount = currentWaveManager.arGameWaveList[nWaveListIndex].nCreateEnemyCount;

    //    InvokeRepeating("generateEnemy", 0.5f, 1.0f);
    //}

    //void generateEnemy()
    //{
        
    //    GameObject testEnemy = Instantiate(prefabEnemy);
    //    testEnemy.transform.position = new Vector3(-30.0f, 30.0f, -2.0f);
    //    nEnemyGeneratingCount++;
    //    addLeftEnemyCount();

    //    if(nEnemyGeneratingCount >= nMaxEnemyCount)
    //    {
    //        CancelInvoke("generateEnemy");
    //        nEnemyGeneratingCount = 0;
    //    }

    //}

    void generateBaseTile(int nSideSize)
    {
        float fPosX;
        float fPosY;
        float fPosZ;
        float fAddPos;
        int nTileIndex;

        nTileIndex = 0;
        fPosX = -30.0f;
        fPosY = 30.0f;
        fPosZ = 0f;
        fAddPos = 10.0f;
        for (int i=0; i < nSideSize; i++)
        {
            for (int j = 0; j < nSideSize; j++)
            {
                GameObject boardTile;
                if (fPosX == -30.0f || fPosX == 30.0f || fPosY == 30.0f || fPosY == -30.0f)
                {
                    boardTile = Instantiate(prefabEnemyPathTile);
                }
                else
                {
                    boardTile = Instantiate(prefabTowerTile);
                }
                
                boardTile.transform.SetParent(objectGameBoard.transform);
                arrBoardTile.Add(boardTile);
                arrBoardTile[nTileIndex].transform.position = new Vector3(fPosX, fPosY, fPosZ);
                arrBoardTile[nTileIndex].name = "baseTile" + nTileIndex;
                fPosX += fAddPos;
                nTileIndex++;
            }
            fPosX = -30.0f;
            fPosY -= fAddPos;
        }
    }
    public void gotoResultScene()
    {
        SceneManager.LoadScene("Junghoon/Scene/PJH_Scene_Result");
    }

}
