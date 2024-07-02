using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public GameObject prefabTowerTile;
    public GameObject prefabEnemyPathTile;
    public GameObject prefabEnemy;
    [SerializeField] GameObject objectGameBoard;
    [SerializeField] UIManager currentUIManager;

    public List<GameObject> arrBoardTile = new List<GameObject>();
    int nEnemyGeneratingCount;

    int nCurrentGold;
    int nEnemyKilled;
    int nLeftEnemy;

    // Start is called before the first frame update
    void Start()
    {
        initGameStatus();
        generateBaseTile(7);
        startWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCurrentGold()
    {
        return nCurrentGold;
    }

    public void addCurrentGold(int nAddValue)
    {
        nCurrentGold += nAddValue;
    }

    public void addEnemyKilled()
    {
        nEnemyKilled++;
    }

    public int getCurrentEnemyKilled()
    {
        return nEnemyKilled;
    }

    public int getCurrentLeftEnemy()
    {
        return nLeftEnemy;
    }

    void addLeftEnemyCount()
    {
        nLeftEnemy++;
        currentUIManager.updateCurrentLeftEnemy();
    }

    public void minusLeftEnemyCount()
    {
        nLeftEnemy--;
        currentUIManager.updateCurrentLeftEnemy();
    }

    void initGameStatus()
    {
        nCurrentGold = 0;
        nEnemyGeneratingCount = 0;
        nEnemyKilled = 0;
        nLeftEnemy = 0;
    }

    void startWave()
    {
        InvokeRepeating("generateEnemy", 0.5f, 1.0f);
    }

    void generateEnemy()
    {
        
        GameObject testEnemy = Instantiate(prefabEnemy);
        testEnemy.transform.position = new Vector3(-30.0f, 30.0f, -2.0f);
        nEnemyGeneratingCount++;
        addLeftEnemyCount();

        if(nEnemyGeneratingCount >= 3)
        {
            CancelInvoke("generateEnemy");
            nEnemyGeneratingCount = 0;
        }

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

}
