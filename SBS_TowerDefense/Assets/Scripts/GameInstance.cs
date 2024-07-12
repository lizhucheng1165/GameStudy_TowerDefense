using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : Singleton<GameInstance>
{
    private GameObject m_lobbyUIManager;
    private GameObject m_gameUIManager;
    private GameObject m_endUIManager;
    private GameObject m_gameManager;

    [SerializeField] private TowerConfig m_towerConfig;
    [SerializeField] private TowerModifierConfig m_towerModifierConfig;
    [SerializeField] private BulletConfig m_bulletConfig;
    [SerializeField] private BulletEffectConfig m_bulletEffectConfig;
    [SerializeField] private MonsterConfig m_monsterConfig;
    [SerializeField] private MonsterModifierConfig m_monsterModifierConfig;
    [SerializeField] private WaveConfig m_waveConfig;
    [SerializeField] private RatingColorConfig m_ratingColorConfig;
    [SerializeField] private RatingTextConfig m_ratingTextConfig;
    [SerializeField] private GlobalConfig m_globalConfig;

    [SerializeField] private GameObject m_tilePrefab;
    public GameObject tilePrefab { get { return m_tilePrefab; } }

    private int m_currentWave;
    private int m_difficulty;
    private float m_time;
    private int m_bestWave;

    /*==================================================================================================*/

    public GameObject lobbyUIManager { get { return m_lobbyUIManager;} set { m_lobbyUIManager = value; } }
    public GameObject gameUIManager { get { return m_gameUIManager; } set { m_gameUIManager = value; } }
    public GameObject endUIManager { get { return m_endUIManager; } set { m_endUIManager = value; } }
    public GameObject gameManager { get { return m_gameManager; } set { m_gameManager = value; } }
    public int difficulty { get { return m_difficulty; } set { m_difficulty = value; } }
    public int bestWave { get { return m_bestWave; } set { m_bestWave = value; } }
    public int currentWave { get { return m_currentWave; } set { m_currentWave = value; } }
    public MonsterConfig monsterConfig { get { return m_monsterConfig; } set { m_monsterConfig = value; } }
    public BulletConfig bulletConfig { get { return m_bulletConfig; } set { m_bulletConfig = value; } }
    public TowerConfig towerConfig { get { return m_towerConfig; } set { m_towerConfig = value; } }
    public WaveConfig waveConfig { get { return m_waveConfig; } set { m_waveConfig = value; } }
    public RatingColorConfig ratingColorConfig { get { return m_ratingColorConfig; } set { m_ratingColorConfig = value; } }
    public RatingTextConfig ratingTextConfig { get { return m_ratingTextConfig; } set { m_ratingTextConfig = value; } }
    public GlobalConfig globalConfig { get { return m_globalConfig; } set { m_globalConfig = value; } }
    
    private void Start()
    {
        DontDestroyOnLoad(Instance);
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }


    //¾À º¯°æ ½Ã
    private void OnActiveSceneChanged(Scene previousScene, Scene newScene)
    {
        if (newScene.name == "Game")
        {
            m_gameUIManager = new GameObject("GameUIManager");
            m_gameUIManager.AddComponent<GameUIManager>();

            m_gameManager = new GameObject("GameManager");
            m_gameManager.AddComponent<GameManager>();

            EventBus.Publish(EventBusType.GAMESTART);
        }
        else if (newScene.name == "End")
        {
            m_endUIManager = new GameObject("EndUIManager");
            m_endUIManager.AddComponent<EndUIManager>();
        }
        else if (newScene.name == "End")
        {
            m_lobbyUIManager = new GameObject("LobbyUIManager");
            m_lobbyUIManager.AddComponent<LobbyUIManager>();
        }
    }


}
