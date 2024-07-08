using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseTile : MonoBehaviour
{
    //[SerializeField] GameObject prefabTower_01;
    //[SerializeField] GameObject prefabTower_02;
    //[SerializeField] GameObject prefabTower_03;
    //[SerializeField] GameObject prefabTower_04;

    [SerializeField] List<GameObject> arPrefabTower;

    [SerializeField] InGameManager currentGameManager;
    GameObject currentTower;

    // Start is called before the first frame update
    void Start()
    {
        currentGameManager = GameObject.FindObjectOfType<InGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (currentGameManager.nCurrentSelectedBuildTowerNumber != 0)
        {
            int tempGold;
            tempGold = currentGameManager.getCurrentGold();
            if (tempGold >= 10)
            {
                currentGameManager.minusCurrentGold(10);
                createTower();
            }
        }

    }

    void createTower()
    {
        int nCurrentSelectedTowerNum = currentGameManager.nCurrentSelectedBuildTowerNumber;
        nCurrentSelectedTowerNum--;
        currentTower = Instantiate(arPrefabTower[nCurrentSelectedTowerNum]);
        currentTower.gameObject.transform.SetParent(this.gameObject.transform);
        currentTower.transform.localPosition = new Vector3(0, 0, 0);
        currentTower.transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);
    }
}
