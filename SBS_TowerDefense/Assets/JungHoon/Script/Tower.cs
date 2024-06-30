using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] GameObject prefabProjectile;
    GameObject myProjectile;
    [SerializeField] GameObject currentTargetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        myProjectile = Instantiate(prefabProjectile);
        myProjectile.GetComponent<Projectile>().myParentGameObject = this.gameObject;
        myProjectile.gameObject.transform.SetParent(this.gameObject.transform);
        myProjectile.gameObject.transform.localPosition = Vector3.zero;
        myProjectile.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void shootProjectile(GameObject currentTargetGameObject)
    {
        myProjectile.SetActive(true);
        myProjectile.GetComponent<Projectile>().myTarget = currentTargetGameObject;
        myProjectile.GetComponent<Projectile>().calculateMoveVector();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentTargetEnemy == null && other.CompareTag("Enemy") == true)
        {
            currentTargetEnemy = other.gameObject;
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
