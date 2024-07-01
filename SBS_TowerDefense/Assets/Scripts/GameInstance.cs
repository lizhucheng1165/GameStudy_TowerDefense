using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : Singleton<GameInstance>
{
    private GameObject m_lobbyUIManager;
    [SerializeField] private GameUIManager m_gameUIManager;
    [SerializeField] private ClearUIManager m_clearUIManager;
    [SerializeField] private TowerConfig m_towerConfig;
    [SerializeField] private TowerModifierConfig m_towerModifierConfig;
    [SerializeField] private BulletConfig m_bulletConfig;
    [SerializeField] private BulletEffectConfig m_bulletEffectConfig;
    [SerializeField] private MonsterConfig m_monsterConfig;
    [SerializeField] private MonsterModifierConfig m_monsterModifierConfig;

    private void Awake()
    {
        m_lobbyUIManager = new GameObject("LobbyUIManager");
        m_lobbyUIManager.AddComponent<LobbyUIManager>();
    }
}
