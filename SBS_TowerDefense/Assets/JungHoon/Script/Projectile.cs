using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    NormalBullet,
    ExplosiveBullet,
    StickyType
}

public class Projectile : MonoBehaviour
{
    public GameObject myParentGameObject;
    public GameObject myTarget;
    Vector3 vec3MoveVector;
    [SerializeField] float fDamage;
    SphereCollider mySphereCollider;
    [SerializeField] ProjectileType currentProjectileType;
    int nCollideCount;
    [SerializeField] Material mBullet_Normal;
    [SerializeField] Material mBullet_Bomb;
    [SerializeField] Material mBullet_Sticky;

    // Start is called before the first frame update
    void Start()
    {
        mySphereCollider = this.GetComponent<SphereCollider>();
        nCollideCount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (myTarget != null)
        {
            moveToTarget();
        }
    }

    void resizeColliderRadius(ProjectileType currentType)
    {
        mySphereCollider.radius = 0.5f;
        if (currentType == ProjectileType.ExplosiveBullet || currentType == ProjectileType.StickyType)
        {
            mySphereCollider.radius = 3.0f;
            Debug.Log("Radius expand to 3.0f");
        }
    }
    public void setProjectileType(ProjectileType nInputType)
    {
        currentProjectileType = nInputType;
        SetProjectileMaterial();
    }

    void SetProjectileMaterial()
    {
        if(currentProjectileType == ProjectileType.NormalBullet)
        {
            this.GetComponent<MeshRenderer>().material = mBullet_Normal;
        }
        else if(currentProjectileType == ProjectileType.ExplosiveBullet)
        {
            this.GetComponent<MeshRenderer>().material = mBullet_Bomb;
        }
        else if (currentProjectileType == ProjectileType.StickyType)
        {
            this.GetComponent<MeshRenderer>().material = mBullet_Sticky;
        }
    }

    public void initMyDamage(float fInputDamage)
    {
        fDamage = fInputDamage;
    }

    public void calculateMoveVector()
    {
        vec3MoveVector = myTarget.transform.position - this.gameObject.transform.position;
    }

    void moveToTarget()
    {
        this.gameObject.transform.position += new Vector3(vec3MoveVector.x * Time.deltaTime * 8.0f, vec3MoveVector.y * Time.deltaTime * 8.0f, vec3MoveVector.z * Time.deltaTime * 8.0f);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == myTarget)
        {
            Debug.Log("OnTriggerEntered..");
            resizeColliderRadius(currentProjectileType);
            vec3MoveVector = Vector3.zero;
        }

        if (other.CompareTag("Enemy") == true)
        {
            nCollideCount++;

            other.gameObject.GetComponent<Enemy>().minusMyHealth(fDamage);
            
            if (currentProjectileType == ProjectileType.StickyType)
            {
                other.gameObject.GetComponent<Enemy>().minusMySpeed(0.05f);
            }
            Debug.Log(nCollideCount + "-" + other.name);

        }

        Invoke("resetProjectilePosition", 0.15f);
        
    }

    void resetProjectilePosition()
    {
        this.gameObject.transform.localPosition = Vector3.zero;
        myTarget = null;
        this.gameObject.SetActive(false);
        mySphereCollider.radius = 0.5f;
        nCollideCount = 0;
        CancelInvoke();
    }

}
