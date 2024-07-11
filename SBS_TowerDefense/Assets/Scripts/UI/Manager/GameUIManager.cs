using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private GameObject m_selectedTile;
    private GameObject m_selectedTower;

    private Canvas m_canvasTower;
    private GameObject m_towerInfoUIPrefab;
    private GameObject m_towerInfoUIInstance;

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

    public GameObject selectedTile { get { return m_selectedTile; } }

    private void Awake()
    {
        m_timerUI = GameObject.Find("TMP_Timer").GetComponent<TextMeshProUGUI>();
        monsterCountUI = GameObject.Find("TMP_MonsterCount").GetComponent<TextMeshProUGUI>();
        waveUI = GameObject.Find("TMP_Wave").GetComponent<TextMeshProUGUI>();
        moneyUI = GameObject.Find("TMP_Money").GetComponent<TextMeshProUGUI>();
        m_canvasTile = GameObject.Find("Canvas_Tile").GetComponent<Canvas>();
        m_canvasTower = GameObject.Find("Canvas_Tower").GetComponent<Canvas>();

        m_tileUIPrefab = Resources.Load<GameObject>("Prefabs/UI/Game/Panel_TileUI");
        m_towerInfoUIPrefab = Resources.Load<GameObject>("Prefabs/UI/Game/Panel_TowerInfoUI");

        m_playerInput = gameObject.AddComponent<PlayerInput>();
        m_playerInput.actions = Resources.Load<InputActionAsset>("InputActions/InputActionManager");
        m_playerInput.actions.Enable();

        EventBus.Subscribe(EventBusType.MONSTER_HIT, UpdateHPBar);
        EventBus.Subscribe(EventBusType.SPAWN_FINALBOSS, SetFinalBossWaveUI);
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

    public void OnTileClick()
    {
        removaAllIndicators();
        if (!EventSystem.current.IsPointerOverGameObject()) //?UI 선택이 아닌경우
        {
            if (m_selectedTile != null)
            {
                removeTileUI();
                return;
            }

            Tile tile = null;
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {

                if (hit.collider.gameObject.TryGetComponent<Tile>(out tile))
                {
                    m_selectedTile = hit.collider.gameObject;
                    if (tile.isBuildable && tile.GetComponentInChildren<Tower>() == null)
                    {
                        //TODO: 3d오브젝트 클릭 시 UI 생성 (다른 캔버스에)
                        Vector3 towerPosition = tile.transform.position + Vector3.up;
                        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, towerPosition);
                        m_tileUIInstance = Instantiate<GameObject>(m_tileUIPrefab, screenPos, tile.transform.rotation);
                        m_tileUIInstance.transform.GetComponentInChildren<UnityEngine.UI.Button>().onClick.AddListener(buyTower);
                        m_tileUIInstance.transform.SetParent(m_canvasTile.transform);

                        m_selectedTile.GetComponent<Tile>().isCliecked = true;
                        m_selectedTile.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Material_Tile_Buildable_Clicked");
                    }
                }
            }
        }
    }

    public void OnTowerClick()
    {
        removaAllIndicators();
        if (!EventSystem.current.IsPointerOverGameObject()) //?UI 선택이 아닌경우
        {
            if (m_selectedTower != null)
            {
                removeTowerUI();
                return;
            }

            Tower tower = null;
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {

                if (hit.collider.gameObject.TryGetComponent<Tower>(out tower))
                {
                    m_selectedTower = hit.collider.gameObject;
                    Vector3 towerPosition = tower.transform.position + Vector3.up;
                    Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, towerPosition);
                    m_towerInfoUIInstance = Instantiate<GameObject>(m_towerInfoUIPrefab, screenPos, Quaternion.identity);
                    m_towerInfoUIInstance.transform.GetComponentInChildren<UnityEngine.UI.Button>().onClick.AddListener(() => combineTower(tower));
                    m_towerInfoUIInstance.transform.SetParent(m_canvasTower.transform);
                    setTowerInfoUIText(tower);
                }
            }
        }
    }

    private void removaAllIndicators()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Indicator"))
        {
            Destroy(item);
        }
    }

    private void setTowerInfoUIText(Tower tower)
    {
        TextMeshProUGUI tmpRating = m_towerInfoUIInstance.transform.Find("TMP_Rating").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI tmpName = m_towerInfoUIInstance.transform.Find("TMP_Name").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI tmpBulletInfo = m_towerInfoUIInstance.transform.Find("TMP_Info_BulletInfo").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI tmpRpm = m_towerInfoUIInstance.transform.Find("TMP_Info_Rpm").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI tmpMinRange = m_towerInfoUIInstance.transform.Find("TMP_Info_MinRange").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI tmpMaxRange = m_towerInfoUIInstance.transform.Find("TMP_Info_MaxRange").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI tmpTargetRange = m_towerInfoUIInstance.transform.Find("TMP_Info_Target_Range").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI tmpTargetMonster= m_towerInfoUIInstance.transform.Find("TMP_Info_Target_Monster").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI tmpDescription= m_towerInfoUIInstance.transform.Find("TMP_Info_Description").GetComponent<TextMeshProUGUI>();

        tmpRating.text = "<<"+GameInstance.Instance.ratingTextConfig.ratingTexts[tower.rating]+">>";
        tmpRating.color = GameInstance.Instance.ratingColorConfig.ratingColors[tower.rating];

        tmpName.text = tower.towerName;
        tmpRpm.text = "발사속도 : " + Math.Round(tower.rpm / 60, 2) + "발 / 초";
        tmpMinRange.text = "최소 사거리 : " + tower.minRange + "m";
        tmpMaxRange.text = "최대 사거리 : " + tower.maxRange + "m";

        string targetRange = "근거리";
        if (tower.priorityTargetRange == Enums.RangeType.Long)
            targetRange = "원거리";
        tmpTargetRange.text = "우선 타겟 (사거리) : " + targetRange;
        tmpTargetMonster.text = "우선 타겟 (몬스터) : 일반";

        tmpDescription.text = "\"" + tower.description + "\"";
    }

    private void removeTileUI()
    {
        m_selectedTile.GetComponent<Tile>().isCliecked = false;
        m_selectedTile.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Material_Tile_Buildable");
        m_selectedTile = null;
        Destroy(m_tileUIInstance);
    }

    private void removeTowerUI()
    {
        m_selectedTower = null;
        Destroy(m_towerInfoUIInstance);
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
        moneyUI.text = string.Format("$ {0}", money);
    }

    public void buyTower()
    {
        EventBus.Publish(EventBusType.BUY_TOWER);
        removeTileUI();

    }

    public void combineTower(Tower tower)
    {
        GameInstance.Instance.gameManager.GetComponent<GameManager>().combineTower(tower);
        removeTowerUI();
    }

    private void SetFinalBossWaveUI()
    {
        waveUI.text = "!! Final Wave !!";

    }
}
