using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerSpawner : MonoBehaviour
{
    Button button;
    public Tile[] tiles;
    public TowerType towerType;
    //public GameObject towerInfoUI;
    //RectTransform towerInfoUIRectTransform;
    private void Awake()
    {
        if (TryGetComponent<Button>(out button))
        {
            foreach (Tile tile in tiles)
            {
                AddEvents(tile);
            }
        }
        
        button.onClick.AddListener(ResetTileSelection);
        //towerInfoUIRectTransform = towerInfoUI.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.Instance.currentGameState == GameState.TILE_SELECTED)
        {
            ResetTileSelection();
            UIManager.Instance.SetUpTowerSpawnCancleUI();
        }
         
    }
    private void OnMouseOver()
    {
        //print("마우스오버");
        ////마우스위치에 UI를 띄운다
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(towerInfoUIRectTransform, Input.mousePosition, null, out Vector2 localPoint);
        //towerInfoUIRectTransform.anchoredPosition = localPoint;
    }
    
    public void AddEvents(Tile tile)
    {
        switch (towerType)
        {
            case TowerType.NOMAL:
                button.onClick.AddListener(tile.OnNomalSelected);
                break;
            case TowerType.SNIPER:
                button.onClick.AddListener(tile.OnSniperSelected);
                break;
            case TowerType.SLOW:
                button.onClick.AddListener(tile.OnSlowSelected);
                break;
        }
    }

    public void ResetTileSelection()
    {
        GameManager.Instance.currentGameState = GameState.PLAYING;
        foreach (Tile tile in tiles)
        {
            tile.isSelected = false;
        }
    }

}
