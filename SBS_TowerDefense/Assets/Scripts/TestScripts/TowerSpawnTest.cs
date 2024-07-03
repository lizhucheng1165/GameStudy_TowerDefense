using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerSpawnTest : MonoBehaviour
{
    Button button;
    public Tile[] test;
    private void Awake()
    {
        button = GetComponent<Button>();
        foreach (var item in test)
        {
            button.onClick.AddListener(item.OnNomalSelected);
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            button.onClick.Invoke();
        }
    }
}
