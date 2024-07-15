using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private float bossHealthPoint = 50f;
    [SerializeField] private int bossBounty = 200;

    protected override void Start()
    {
        base.Start();
        healthPoint = bossHealthPoint; // Set higher health for boss enemy
        bounty = bossBounty;
    }

    protected override void Die()
    {
        Destroy(gameObject);
        WaveManager.DecreaseEnemyCount();
        Debug.Log("Enemy Killed");
        Resources.AddMoney(bounty);
    }
}