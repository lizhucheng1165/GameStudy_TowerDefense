using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    ArcherTower,
    SniperTower,
    BombTower,
    StickyTower
}

public class Tower : MonoBehaviour
{

    [SerializeField] GameObject prefabProjectile;
    GameObject myProjectile;
    [SerializeField] GameObject currentTargetEnemy;
    float fShootDelayTime;
    [SerializeField] bool bCanShoot;
    Coroutine coroutine;
    public TowerType myTowerType;

    // Start is called before the first frame update
    void Start()
    {
        myProjectile = Instantiate(prefabProjectile);
        myProjectile.GetComponent<Projectile>().initMyDamage(1.0f);
        myProjectile.GetComponent<Projectile>().myParentGameObject = this.gameObject;
        myProjectile.gameObject.transform.SetParent(this.gameObject.transform);
        myProjectile.gameObject.transform.localPosition = Vector3.zero;
        myProjectile.SetActive(false);
        fShootDelayTime = 1.0f;
        bCanShoot = true;

        setTowerProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setTowerProjectile()
    {
        if(myTowerType == TowerType.ArcherTower)
        {
            myProjectile.GetComponent<Projectile>().setProjectileType(ProjectileType.NormalBullet);
        }
        else if(myTowerType == TowerType.SniperTower)
        {
            myProjectile.GetComponent<Projectile>().setProjectileType(ProjectileType.NormalBullet);
            myProjectile.GetComponent<Projectile>().initMyDamage(2.0f);
        }
        else if (myTowerType == TowerType.BombTower)
        {
            myProjectile.GetComponent<Projectile>().setProjectileType(ProjectileType.ExplosiveBullet);
        }
        else if (myTowerType == TowerType.StickyTower)
        {
            myProjectile.GetComponent<Projectile>().setProjectileType(ProjectileType.StickyType);
        }

    }

    public void setTowerProjectileType()
    {
        setTowerProjectile();
    }

    IEnumerator waitForShootableStatus(float fWaitTime)
    {
        yield return new WaitForSeconds(fWaitTime);
        bCanShoot = true;
    }

    void shootProjectile(GameObject currentTargetGameObject)
    {
        myProjectile.SetActive(true);
        myProjectile.GetComponent<Projectile>().myTarget = currentTargetGameObject;
        myProjectile.GetComponent<Projectile>().calculateMoveVector();
        bCanShoot = false;
        coroutine = StartCoroutine(waitForShootableStatus(fShootDelayTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentTargetEnemy == null && other.CompareTag("Enemy") == true)
        {
            currentTargetEnemy = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentTargetEnemy == null && other.CompareTag("Enemy") == true)
        {
            currentTargetEnemy = other.gameObject;
        }

        if (currentTargetEnemy != null && bCanShoot == true)
        {
            shootProjectile(currentTargetEnemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentTargetEnemy)
        {
            currentTargetEnemy = null;
        }
    }
}
