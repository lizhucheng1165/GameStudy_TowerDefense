using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class GameUIManager : MonoBehaviour
{
    private GameObject m_selectedObject;
    private Canvas m_canvas;
    private GameObject m_tileUIPrefab;

    private TextMeshProUGUI m_timerUI;
    private TextMeshProUGUI m_monsterCountUI;
    private TextMeshProUGUI m_waveUI;

    public TextMeshProUGUI timerUI { get { return m_timerUI; } set { m_timerUI = value; } }
    public TextMeshProUGUI monsterCountUI { get { return m_monsterCountUI; } set { m_monsterCountUI = value; } }
    public TextMeshProUGUI waveUI { get { return m_waveUI; } set { m_waveUI = value; } }
    public GameObject selectedObject { get { return m_selectedObject; } }

    private void Awake()
    {
        //m_timerUI = Resources.Load<TextMeshProUGUI>("Prefabs/UI/Game/TMP_Timer");
        m_timerUI = GameObject.Find("TMP_Timer").GetComponent<TextMeshProUGUI>();
        monsterCountUI = GameObject.Find("TMP_MonsterCount").GetComponent<TextMeshProUGUI>();
        waveUI = GameObject.Find("TMP_Wave").GetComponent<TextMeshProUGUI>();
        m_canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        m_tileUIPrefab = Resources.Load<GameObject>("Prefabs/UI/Game/Panel_TileUI");
        //m_canvas = Resources.Load<Canvas>("Prefabs/UI/Game/Canvas_TileUI");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되었을 때
        if (Input.GetMouseButtonDown(0))
        {
            if (m_selectedObject == null)
            {
                Tile tile = null;
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    m_selectedObject = hit.collider.gameObject;

                    if (m_selectedObject.TryGetComponent<Tile>(out tile))
                    {
                        if (tile.isBuildable)
                        {
                            //TODO: 3d오브젝트 클릭 시 UI 생성 (다른 캔버스에)
                            Vector3 tilePosition = tile.transform.position;
                            //Instantiate<GameObject>(m_tileUIPrefab, tilePosition, )
                        }
                    }
                }
            }
            else if (m_selectedObject != null)
            {
                m_selectedObject = null;
            }
        }
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
}
