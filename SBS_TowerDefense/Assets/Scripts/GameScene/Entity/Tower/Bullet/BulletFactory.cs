using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletFactory
{
    private List<Bullet> m_bullets;

    public List<Bullet> bullets {  get { return m_bullets; } }

    public BulletFactory()
    {
        m_bullets = GameInstance.Instance.bulletConfig.bullets;
    }

    public Bullet SpawnBullet(int bulletId)
    {
        Bullet findBullet = null;
        foreach (Bullet bullet in m_bullets)
        {
            if (bullet.bulletId == bulletId)
                findBullet = bullet;
        }

        if (findBullet == null)
            return null;

        findBullet.transform.position = Vector3.zero + Vector3.up;
        return PrefabUtility.InstantiatePrefab(findBullet) as Bullet;
    }
}
