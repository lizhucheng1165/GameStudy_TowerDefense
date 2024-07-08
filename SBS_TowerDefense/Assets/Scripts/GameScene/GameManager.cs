using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private TileFactory m_tileFactory;
    private MonsterFactory m_monsterFactory;
    private Player m_player;
    private Tile[,] m_tiles;
    private GameUIManager m_gameUIManager;
    private int m_monsterCount;

    private Coroutine timerCoroutine;
    private void Awake()
    {
        m_gameUIManager = GameInstance.Instance.gameUIManager.GetComponent<GameUIManager>();
        //m_gameUIManager.timerUI = GameInstance.Instance.gameUIManager.GetComponent<GameUIManager>().timerUI;
        //m_tmpMonsterCount = GameInstance.Instance.gameUIManager.GetComponent<GameUIManager>().monsterCountUI;
        m_player = new Player();
        m_tileFactory = new TileFactory(GameInstance.Instance.tilePrefab.GetComponent<Tile>());
        m_monsterFactory = new MonsterFactory();
        EventBus.Subscribe(EventBusType.GAMESTART, breakTimeStart);
        EventBus.Subscribe(EventBusType.BREAKTIME_START, breakTimeStart);
        EventBus.Subscribe(EventBusType.WAVE_START, startWave);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    //게임 시작 - 대기시간 - 웨이브 - 대기시간 - 웨이브

    IEnumerator SpawnMonsterForSecond(int spawnCount, float spawnInterval, int monsterId)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            m_monsterFactory.SpawnMonster(monsterId);
            m_monsterCount++;
            m_gameUIManager.setMonsterCountUI(m_monsterCount, 100);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator SetTimer(float length, EventBusType type)
    {

        while (length >= 0)
        {
            length -= 0.01f;
            m_gameUIManager.setTimerUI(length);
            yield return new WaitForSeconds(0.01f);
        }

        if (type == EventBusType.GAMESTART || type == EventBusType.BREAKTIME_START)
            EventBus.Publish(EventBusType.WAVE_START);
        else if (type == EventBusType.WAVE_START)
            EventBus.Publish(EventBusType.BREAKTIME_START);
    }

    private void breakTimeStart()
    {
        m_gameUIManager.changeTimerUIColor(new Color(0, 0, 0));
        StartCoroutine(SetTimer(15, EventBusType.BREAKTIME_START));
    }

    private void startWave()
    {
        m_gameUIManager.changeTimerUIColor(new Color(255, 255, 255));
        GameInstance.Instance.currentWave++;
        GameInstance.Instance.bestWave++;

        m_gameUIManager.setWaveUI(GameInstance.Instance.currentWave);

        timerCoroutine = StartCoroutine(SetTimer(60, EventBusType.WAVE_START));

        WaveConfig waveConfig = GameInstance.Instance.waveConfig;

        foreach (Wave wave in waveConfig.waves)
        {
            if (wave.spawnMonsterId == GameInstance.Instance.currentWave)
                StartCoroutine(SpawnMonsterForSecond(wave.spawnCount, wave.spawnInterval, wave.spawnMonsterId));
        }
    }
}
