using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_timerUI;
    [SerializeField] private TextMeshProUGUI m_monsterCountUI;
    [SerializeField] private TextMeshProUGUI m_waveUI;

    public TextMeshProUGUI timerUI { get { return m_timerUI; } set { m_timerUI = value; } }
    public TextMeshProUGUI monsterCountUI { get { return m_monsterCountUI; } set { m_monsterCountUI = value; } }
    public TextMeshProUGUI waveUI { get { return m_waveUI; } set { m_waveUI = value; } }

    private void Awake()
    {
        //m_timerUI = Resources.Load<TextMeshProUGUI>("Prefabs/UI/Game/TMP_Timer");
        m_timerUI = GameObject.Find("TMP_Timer").GetComponent<TextMeshProUGUI>();
        monsterCountUI = GameObject.Find("TMP_MonsterCount").GetComponent<TextMeshProUGUI>();
        waveUI = GameObject.Find("TMP_Wave").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
