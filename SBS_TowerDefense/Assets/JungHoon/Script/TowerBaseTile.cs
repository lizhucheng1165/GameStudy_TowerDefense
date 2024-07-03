using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseTile : MonoBehaviour
{
    [SerializeField] GameObject prefabTower;
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
        int tempGold;
        Debug.Log("clicked: " + this.gameObject.name);
        tempGold = currentGameManager.getCurrentGold();
        if (tempGold >= 10)
        {
            currentGameManager.minusCurrentGold(10);
            createTower();
        }
    }

    void createTower()
    {
        currentTower = Instantiate(prefabTower);
        currentTower.gameObject.transform.SetParent(this.gameObject.transform);
        //currentTower.transform.position = new Vector3(0, 0, 0);
        currentTower.transform.localPosition = new Vector3(0, 0, 0);
        currentTower.transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);
    }
}
