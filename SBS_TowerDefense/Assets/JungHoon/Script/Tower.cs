using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] GameObject prefabProjectile;
    GameObject myProjectile;
    [SerializeField] GameObject currentTargetEnemy;
    float fShootDelayTime;
    [SerializeField] bool bCanShoot;
    Coroutine coroutine;

    // Start is called before the first frame update
    void Start()
    {
        myProjectile = Instantiate(prefabProjectile);
        myProjectile.GetComponent<Projectile>().setProjectileType(ProjectileType.ExplosiveBullet);
        myProjectile.GetComponent<Projectile>().initMyDamage(1.0f);
        myProjectile.GetComponent<Projectile>().myParentGameObject = this.gameObject;
        myProjectile.gameObject.transform.SetParent(this.gameObject.transform);
        myProjectile.gameObject.transform.localPosition = Vector3.zero;
        myProjectile.SetActive(false);
        fShootDelayTime = 1.0f;
        bCanShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitForShootableStatus(float fWaitTime)
    {
        yield return new WaitForSeconds(fWaitTime);
        bCanShoot = true;
        //Debug.Log("now can shoot!");
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
            //shootProjectile(currentTargetEnemy);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentTargetEnemy == null && other.CompareTag("Enemy") == true)
        {
            currentTargetEnemy = other.gameObject;
            //shootProjectile(currentTargetEnemy);
        }

        if (currentTargetEnemy != null && bCanShoot == true)
        {
            //currentTargetEnemy = other.gameObject;
            shootProjectile(currentTargetEnemy);
            //coroutine = StartCoroutine(waitForShootableStatus(fShootDelayTime));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentTargetEnemy)
        {
            currentTargetEnemy = null;
            //StopCoroutine(coroutine);
        }
    }
}
