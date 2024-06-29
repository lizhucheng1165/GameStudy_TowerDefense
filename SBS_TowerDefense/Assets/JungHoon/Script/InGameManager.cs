using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    public GameObject prefabTile;
    public GameObject prefabEnemy;
    [SerializeField] GameObject objectGameBoard;
    //GameObject boardTile;
    public List<GameObject> arrBoardTile = new List<GameObject>();
    int nEnemyGeneratingCount;

    // Start is called before the first frame update
    void Start()
    {
        nEnemyGeneratingCount = 0;
        generateTile(7);
        //generateEnemy();
        startWave();

        //for(int i=0;i<49;i++)
        //{
        //    Debug.Log(arrBoardTile[i].gameObject.name);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
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

        if(nEnemyGeneratingCount >= 3)
        {
            CancelInvoke("generateEnemy");
            nEnemyGeneratingCount = 0;
        }

    }

    void generateTile(int nSideSize)
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
                GameObject boardTile = Instantiate(prefabTile);
                boardTile.transform.SetParent(objectGameBoard.transform);
                arrBoardTile.Add(boardTile);
                arrBoardTile[nTileIndex].transform.position = new Vector3(fPosX, fPosY, fPosZ);
                fPosX += fAddPos;
                nTileIndex++;
            }
            fPosX = -30.0f;
            fPosY -= fAddPos;
        }
    }
}
