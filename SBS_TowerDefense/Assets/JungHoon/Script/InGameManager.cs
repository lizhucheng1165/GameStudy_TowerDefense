using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    int nCurrentGold;
    int nEnemyKilled;
    int nLeftEnemy;
    int nMaxEnemyCount;
    int nCurrentWave;
    int nLastWave;
    public int nCurrentSelectedBuildTowerNumber;

    // Start is called before the first frame update
    void Start()
    {
        initGameStatus();
        generateBaseTile(7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCurrentBulidTowerNumber(int nTowerNumber)
    {
        nCurrentSelectedBuildTowerNumber = nTowerNumber;
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
        nEnemyKilled = 0;
        nLeftEnemy = 0;
        nMaxEnemyCount = 0;
        nCurrentWave = 0;
        nLastWave = 5;
        nCurrentSelectedBuildTowerNumber = 0;
    }

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
