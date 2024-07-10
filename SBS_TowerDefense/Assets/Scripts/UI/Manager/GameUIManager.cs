using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameUIManager : MonoBehaviour
{
    private GameObject m_selectedObject;
    private Canvas m_canvasTile;
    private GameObject m_tileUIPrefab;
    private GameObject m_tileUIInstance;

    private GameObject m_healthBar;

    private PlayerInput m_playerInput;

    private TextMeshProUGUI m_timerUI;
    private TextMeshProUGUI m_monsterCountUI;
    private TextMeshProUGUI m_waveUI;
    private TextMeshProUGUI m_moneyUI;

    public TextMeshProUGUI timerUI { get { return m_timerUI; } set { m_timerUI = value; } }
    public TextMeshProUGUI monsterCountUI { get { return m_monsterCountUI; } set { m_monsterCountUI = value; } }
    public TextMeshProUGUI waveUI { get { return m_waveUI; } set { m_waveUI = value; } }
    public TextMeshProUGUI moneyUI { get { return m_moneyUI; } set { m_moneyUI = value; } }
    public GameObject selectedObject { get { return m_selectedObject; } }

    private void Awake()
    {
        m_timerUI = GameObject.Find("TMP_Timer").GetComponent<TextMeshProUGUI>();
        monsterCountUI = GameObject.Find("TMP_MonsterCount").GetComponent<TextMeshProUGUI>();
        waveUI = GameObject.Find("TMP_Wave").GetComponent<TextMeshProUGUI>();
        moneyUI = GameObject.Find("TMP_Money").GetComponent<TextMeshProUGUI>();
        m_canvasTile = GameObject.Find("Canvas_Tile").GetComponent<Canvas>();
        m_tileUIPrefab = Resources.Load<GameObject>("Prefabs/UI/Game/Panel_TileUI");

        m_playerInput = gameObject.AddComponent<PlayerInput>();

        m_playerInput.actions = Resources.Load<InputActionAsset>("InputActions/InputActionManager");
        m_playerInput.actions.Enable();

        EventBus.Subscribe(EventBusType.MONSTER_HIT, UpdateHPBar);
        EventBus.Subscribe(EventBusType.MONSTER_DEATH, MonsterDeath);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateHPBar()
    {
    }

    private void MonsterDeath()
    {
    }

    public void OnTileClick()
    {

        if (!EventSystem.current.IsPointerOverGameObject()) //?UI 선택인지 판단
        {
            if (m_selectedObject == null)
            {
                Tile tile = null;
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {

                    if (hit.collider.gameObject.TryGetComponent<Tile>(out tile))
                    {
                        m_selectedObject = hit.collider.gameObject;
                        if (tile.isBuildable && tile.GetComponentInChildren<Tower>() == null)
                        {
                            //TODO: 3d오브젝트 클릭 시 UI 생성 (다른 캔버스에)
                            Vector3 tilePosition = tile.transform.position + Vector3.up;
                            Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, tilePosition);
                            m_tileUIInstance = Instantiate<GameObject>(m_tileUIPrefab, screenPos, tile.transform.rotation);
                            m_tileUIInstance.transform.GetComponentInChildren<UnityEngine.UI.Button>().onClick.AddListener(buyTower);
                            m_tileUIInstance.transform.SetParent(m_canvasTile.transform);

                            m_selectedObject.GetComponent<Tile>().isCliecked = true;
                            m_selectedObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Material_Tile_Buildable_Clicked");
                        }
                    }
                }
            }
            else if (m_selectedObject != null)
            {
                removeTileUI();
            }
        }
    }

    private void removeTileUI()
    {
        m_selectedObject.GetComponent<Tile>().isCliecked = false;
        m_selectedObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Material_Tile_Buildable");
        m_selectedObject = null;
        Destroy(m_tileUIInstance);
    }

    public void changeTimerUIColor(Color color)
    {
        timerUI.color = color;
    }

    public void setTimerUI(float time)
    {
        string formattedFloat = "";

        TimeSpan ts = TimeSpan.FromSeconds(time);
        formattedFloat = string.Format("{0:ss\\:ff}", ts);  //format의 이스케이프 문자인 \을 넣기 위해 \\를 넣음
        timerUI.text = formattedFloat;
    }

    public void setMonsterCountUI(int monsterCount, int maxCount)
    {
        monsterCountUI.text = string.Format("{0}/{1}", monsterCount, maxCount);
    }

    public void setWaveUI(int wave)
    {
        waveUI.text = string.Format("{0} Wave", wave);
    }

    public void setMoneyUI(int money)
    {
        moneyUI.text = string.Format("$ {0}",money);
    }

    public void buyTower()
    {
        EventBus.Publish(EventBusType.BUY_TOWER);
        removeTileUI();
    }
}
