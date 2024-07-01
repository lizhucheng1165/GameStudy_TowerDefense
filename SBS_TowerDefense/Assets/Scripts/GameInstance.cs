using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : Singleton<GameInstance>
{
    private GameObject m_lobbyUIManager;
    private GameObject m_gameUIManager;
    private GameObject m_clearUIManager;

    [SerializeField] private TowerConfig m_towerConfig;
    [SerializeField] private TowerModifierConfig m_towerModifierConfig;
    [SerializeField] private BulletConfig m_bulletConfig;
    [SerializeField] private BulletEffectConfig m_bulletEffectConfig;
    [SerializeField] private MonsterConfig m_MonsterConfig;
    [SerializeField] private MonsterModifierConfig m_MonsterModifierConfig;
    [SerializeField] private WaveConfig m_waveConfig;

    [SerializeField] private GameObject m_tilePrefab;

    private int m_difficulty;
    private float m_time;
    private int m_currentWave;
    private int m_bestWave;
    private Player m_player;
    private TileFactory m_tileFactory;
    private Tile[,] m_tiles;

    /*==================================================================================================*/

    public GameObject lobbyUIManager { get { return m_lobbyUIManager;} set { m_lobbyUIManager = value; } }
    public GameObject gameUIManager { get { return m_gameUIManager; } set { m_gameUIManager = value; } }
    public int difficulty { get { return m_difficulty; } set { m_difficulty = value; } }
    public GameObject tilePrefab { get { return m_tilePrefab; } }

    private void Start()
    {
        m_player = new Player();
        m_tileFactory = new TileFactory(m_tilePrefab.GetComponent<Tile>());
        DontDestroyOnLoad(Instance);
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    //씬 변경 시
    private void OnActiveSceneChanged(Scene previousScene, Scene newScene)
    {
        if (newScene.name == "Game")
        {
            m_gameUIManager = new GameObject("GameUIManager");
            m_gameUIManager.AddComponent<GameUIManager>();
            createTiles();                                      //TODO: 씬 마다 매니저 하나 씩 만들고 게임 인스턴스에서 관리, 매니저에서 타일 생성하기
        }
        else if (newScene.name == "Clear")
        {
            m_clearUIManager = new GameObject("ClearUIManager");
            m_clearUIManager.AddComponent<ClearUIManager>();
        }
        else if (newScene.name == "Lobby")
        {
            m_lobbyUIManager = new GameObject("LobbyUIManager");
            m_lobbyUIManager.AddComponent<LobbyUIManager>();
        }
    }

    private void createTiles()
    {
        m_tiles = new Tile[10,10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                m_tiles[i,j] = m_tileFactory.createTile(i,j);
            }
        }
    }
}
