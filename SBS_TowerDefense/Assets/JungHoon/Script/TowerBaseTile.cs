using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBaseTile : MonoBehaviour
{
    [SerializeField] GameObject prefabTower;
    GameObject currentTower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("clicked: " + this.gameObject.name);
        createTower();
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
