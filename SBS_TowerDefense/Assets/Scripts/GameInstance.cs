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

    private GameObject m_gameManager;

    [SerializeField] private TowerConfig m_towerConfig;
    [SerializeField] private TowerModifierConfig m_towerModifierConfig;
    [SerializeField] private BulletConfig m_bulletConfig;
    [SerializeField] private BulletEffectConfig m_bulletEffectConfig;
    [SerializeField] private MonsterConfig m_monsterConfig;
    [SerializeField] private MonsterModifierConfig m_monsterModifierConfig;
    [SerializeField] private WaveConfig m_waveConfig;

    [SerializeField] private GameObject m_tilePrefab;
    public GameObject tilePrefab { get { return m_tilePrefab; } }

    private int m_difficulty;
    private float m_time;
    private int m_currentWave;
    private int m_bestWave;

    /*==================================================================================================*/

    public GameObject lobbyUIManager { get { return m_lobbyUIManager;} set { m_lobbyUIManager = value; } }
    public GameObject gameUIManager { get { return m_gameUIManager; } set { m_gameUIManager = value; } }
    public int difficulty { get { return m_difficulty; } set { m_difficulty = value; } }
    public MonsterConfig monsterConfig { get { return m_monsterConfig; } set { m_monsterConfig = value; } }
    
    private void Start()
    {
        DontDestroyOnLoad(Instance);
        SceneManager.activeSceneChanged += OnActiveSceneChanged;

        m_monsterConfig = Resources.Load<MonsterConfig>("Data/MonsterConfig");
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


}
