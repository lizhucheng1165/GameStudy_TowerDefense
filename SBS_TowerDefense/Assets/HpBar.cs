using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField]
    private GameObject HPBarPrefab = null;
    List<Transform> enemyList = new List<Transform>();
    List<GameObject> HPBarList = new List<GameObject>();

    Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
        GameObject[] targetEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < targetEnemies.Length; i++)
        {
            enemyList.Add(targetEnemies[i].transform);
            GameObject hpBar = Instantiate(HPBarPrefab, targetEnemies[i].transform.position, Quaternion.identity, transform);
            HPBarList.Add(hpBar);
        }
    }

    private void Update()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            HPBarList[i].transform.position = mainCamera.WorldToScreenPoint(enemyList[i].position + new Vector3(0, 0.5f, 0)); 
        }
    }
}
