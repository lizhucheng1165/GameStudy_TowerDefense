using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int m_currentWave;

    private TileFactory m_tileFactory;
    private MonsterFactory m_monsterFactory;
    private Player m_player;
    private Tile[,] m_tiles;

    private void Awake()
    {
        m_player = new Player();
        m_tileFactory = new TileFactory(GameInstance.Instance.tilePrefab.GetComponent<Tile>());
        m_monsterFactory = new MonsterFactory();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsterForSecond(10, 0.5f, 0));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnMonsterForSecond(int spawnCount, float spawnInterval, int monsterId)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            m_monsterFactory.SpawnMonster(monsterId);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
