using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private TileFactory m_tileFactory;
    private MonsterFactory m_monsterFactory;
    private TowerFactory m_towerFactory;
    private Tile[,] m_tiles;
    private GameUIManager m_gameUIManager;
    private int m_monsterCount;
    private int m_maxMonsterCount;

    private Player m_player;
    public Player player { get { return m_player; } }

    private Coroutine timerCoroutine;

    private List<Monster> m_spawnedMonsters = new List<Monster>();
    public List<Monster> spawnedMonsters { get { return m_spawnedMonsters; } set { m_spawnedMonsters = spawnedMonsters; } } 

    private void Awake()
    {
        m_gameUIManager = GameInstance.Instance.gameUIManager.GetComponent<GameUIManager>();
        //m_gameUIManager.timerUI = GameInstance.Instance.gameUIManager.GetComponent<GameUIManager>().timerUI;
        //m_tmpMonsterCount = GameInstance.Instance.gameUIManager.GetComponent<GameUIManager>().monsterCountUI;
        m_player = new Player();
        m_player.money = GameInstance.Instance.globalConfig.startMoney;

        m_maxMonsterCount = 100;

        m_tileFactory = new TileFactory(GameInstance.Instance.tilePrefab.GetComponent<Tile>());
        m_monsterFactory = new MonsterFactory();
        m_towerFactory = new TowerFactory();
        EventBus.Subscribe(EventBusType.GAMESTART, breakTimeStart);
        EventBus.Subscribe(EventBusType.BREAKTIME_START, breakTimeStart);
        EventBus.Subscribe(EventBusType.WAVE_START, startWave);
        EventBus.Subscribe(EventBusType.BUY_TOWER, buyTower);
        EventBus.Subscribe(EventBusType.MONSTER_DEATH, monsterReward);
        EventBus.Subscribe(EventBusType.LOSE, lose);

        m_gameUIManager.setMoneyUI(m_player.money);
    }

    void Start()
    {
    }

    void Update()
    {
        if (m_spawnedMonsters.Count >= m_maxMonsterCount)
        {
            EventBus.Publish(EventBusType.LOSE);
            SceneManager.LoadScene("End");
        }
    }
    /// <summary>
    /// 특정 시간마다 몬스터를 소환하는 코루틴 함수
    /// </summary>
    /// <param name="spawnCount"></param>
    /// <param name="spawnInterval"></param>
    /// <param name="monsterId"></param>
    /// <returns></returns>
    IEnumerator SpawnMonsterForSecond(int spawnCount, float spawnInterval, int monsterId)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            m_spawnedMonsters.Add(m_monsterFactory.SpawnMonster(monsterId));
            m_gameUIManager.setMonsterCountUI(m_spawnedMonsters.Count, m_maxMonsterCount);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    /// <summary>
    /// 타이머 설정하는 코루틴 재귀함수
    /// </summary>
    /// <param name="length"></param>
    /// <param name="type"></param>
    /// <returns></returns>
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
        else if (type == EventBusType.SPAWN_FINALBOSS)
            EventBus.Publish(EventBusType.LOSE);
    }

    private void spawnFinalBoss()
    {
        float bossHealth = GameInstance.Instance.globalConfig.finalBossBaseHealth * GameInstance.Instance.difficulty;

        foreach (Monster monster in m_spawnedMonsters)
        {
            bossHealth += monster.currentHealth;
        }

        EventBus.Publish(EventBusType.SPAWN_FINALBOSS);

        m_monsterFactory.SpawnFinalBoss(bossHealth);
    }

    /// <summary>
    /// 이벤트 버스 BREAKTIME_START publish 시 실행되는 휴식시간 시작 함수
    /// </summary>
    private void breakTimeStart()
    {
        m_gameUIManager.changeTimerUIColor(new Color(0, 0, 0));
        StartCoroutine(SetTimer(GameInstance.Instance.globalConfig.breakTimeLength, EventBusType.BREAKTIME_START));
    }

    /// <summary>
    /// 이벤트 버스 WAVE_START publish 시 실행되는 웨이브 시작 함수
    /// </summary>
    private void startWave()
    {
        //현재 웨이브가 마지막 웨이브면
        if (GameInstance.Instance.currentWave == GameInstance.Instance.waveConfig.waves.Count)
        {
            spawnFinalBoss();
            StartCoroutine(SetTimer(GameInstance.Instance.globalConfig.finalBossTimeLength, EventBusType.SPAWN_FINALBOSS));
            return;
        }

        GameInstance.Instance.currentWave++;
        GameInstance.Instance.bestWave++;
        if (GameInstance.Instance.currentWave != 1)
        {
            player.money += 50 + GameInstance.Instance.currentWave * 10;
            m_gameUIManager.setMoneyUI(player.money);
        }

        m_gameUIManager.changeTimerUIColor(new Color(255, 255, 255));
        m_gameUIManager.setWaveUI(GameInstance.Instance.currentWave);

        timerCoroutine = StartCoroutine(SetTimer(GameInstance.Instance.globalConfig.waveTimeLength, EventBusType.WAVE_START));

        WaveConfig waveConfig = GameInstance.Instance.waveConfig;

        foreach (Wave wave in waveConfig.waves)
        {
            if (wave.waveNumber == GameInstance.Instance.currentWave)
                StartCoroutine(SpawnMonsterForSecond(wave.spawnCount, wave.spawnInterval, wave.spawnMonsterId));
        }
    }

    /// <summary>
    /// 타워 구매 함수
    /// </summary>
    private void buyTower()
    {
        if (m_player.money >= 100)
        {
            Tile selectedTile = m_gameUIManager.selectedTile.GetComponent<Tile>();
            m_player.money -= 100;

            m_towerFactory.SpawnRandomTowerOfRating(selectedTile, 1);
            m_gameUIManager.setMoneyUI(m_player.money);
        }
    }

    /// <summary>
    /// 타입과 등급이 같은 가장 가까운 타워 조합 (조합가능한 타워가 3개 이상이거나 같은 거리에있는게 많은경우 버그발생)
    /// </summary>
    /// <param name="inputTower"></param>
    public void combineTower(Tower inputTower)
    {
        Tile parentTile = inputTower.transform.GetComponentInParent<Tile>();
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Tower");

        for (int i = 0; i < gameObjects.Length; i++) 
        {
            if (gameObjects[i].GetComponent<Tower>() == inputTower)
            {
                List<GameObject> list = gameObjects.ToList();
                list.RemoveAt(i);
                gameObjects = list.ToArray();
            }
        }

        if (gameObjects.Length <= 0)
            return;

        List<Tower> combineableTowers = new List<Tower>();
        foreach (GameObject gameObject in gameObjects)
        {
            Tower comparativeTower = gameObject.GetComponent<Tower>();

            if (inputTower.rating == comparativeTower.rating && inputTower.type == comparativeTower.type)
                combineableTowers.Add(comparativeTower);

        }

        if (combineableTowers.Count <= 0)
            return;

        Tower closestTower = combineableTowers[0];
        float closestDistance = Vector3.Distance(inputTower.transform.position, closestTower.transform.position);

        foreach (Tower combineableTower in combineableTowers)
        {
            float distance = Vector3.Distance(inputTower.transform.position, combineableTower.transform.position);

            if (closestDistance > distance)
            {
                closestDistance = distance;
                closestTower = combineableTower;
            }
            Destroy(inputTower.gameObject);
            Destroy(closestTower.gameObject);
            m_towerFactory.SpawnRandomTowerOfRating(parentTile, inputTower.rating + 1);
        }
    }

    /// <summary>
    /// 몬스터 처치 시 실행되는 함수
    /// </summary>
    private void monsterReward()
    {
        m_player.money += 3 + GameInstance.Instance.currentWave / 2;
        m_gameUIManager.setMonsterCountUI(m_spawnedMonsters.Count, m_maxMonsterCount);
        m_gameUIManager.setMoneyUI(m_player.money);
    }

    private void lose()
    {
        SceneManager.LoadScene("End");
    }
}
