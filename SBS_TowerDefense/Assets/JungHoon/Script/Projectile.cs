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
    float fDamage;
    SphereCollider mySphereCollider;
    ProjectileType currentProjectileType;
    //float fDistanceToTargetPosition;
    int nCollideCount;
    List<GameObject> arDetectedEnemy = new List<GameObject>();
    //bool bHit;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.transform.position = Vector3.zero;
        //fDistanceToTargetPosition = 0f;
        mySphereCollider = this.GetComponent<SphereCollider>();
        nCollideCount = 0;
        //bHit = false;
        //Debug.Log("detected enemy array count: " + arDetectedEnemy.Count);

    }

    // Update is called once per frame
    void Update()
    {
        if (myTarget != null)
        {
            moveToTarget();
            //findDistanceToTargetLocation();
        }



        //Debug.Log("dist to target: "+fDistanceToTargetPosition);
        //if(fDistanceToTargetPosition <= 1.0f)
        //{
        //    setColliderActive(true);
        //    Debug.Log("collider active..");
        //}

    }

    //bool findDistanceToTargetLocation()
    //{
    //    fDistanceToTargetPosition = Vector3.Distance(myTarget.transform.position, this.gameObject.transform.position);

    //    return true;
    //}

    //public void setColliderActive(bool bActive)
    //{
    //    mySphereCollider.enabled = bActive;
    //}

    //public void initExplosiveBullet()
    //{
    //    mySphereCollider = this.GetComponent<SphereCollider>();

    //}

    void resizeColliderRadius(ProjectileType currentType)
    {
        mySphereCollider.radius = 0.5f;
        if (currentType == ProjectileType.ExplosiveBullet)
        {
            mySphereCollider.radius = 3.0f;
            Debug.Log("Radius expand to 3.0f");
        }
    }
    public void setProjectileType(ProjectileType nInputType)
    {
        currentProjectileType = nInputType;
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

            //other.gameObject.GetComponent<Enemy>().minusMyHealth(fDamage);

            //this.gameObject.transform.localPosition = Vector3.zero;
            //myTarget = null;
            //this.gameObject.SetActive(false);
            //mySphereCollider.radius = 0.5f;
        }

        if (other.CompareTag("Enemy") == true)
        {
            //this.gameObject.transform.localPosition = Vector3.zero;
            //myTarget = null;
            //this.gameObject.SetActive(false);
            //Debug.Log("OnTriggerEntered..");
            //other.gameObject.GetComponent<Enemy>().minusMyHealth(fDamage);

            arDetectedEnemy.Add(other.gameObject);
            nCollideCount++;
            //Debug.Log("collideCount: " + nCollideCount);

            other.gameObject.GetComponent<Enemy>().minusMyHealth(fDamage);
            //this.gameObject.transform.localPosition = Vector3.zero;
            //myTarget = null;
            //this.gameObject.SetActive(false);
            //mySphereCollider.radius = 0.5f;
            Debug.Log("detected enemy array count: " + arDetectedEnemy.Count);
        }


        //int nTargetCount = 0;
        //while(nTargetCount < arDetectedEnemy.Count)
        //{
        //    arDetectedEnemy[nTargetCount].GetComponent<Enemy>().minusMyHealth(fDamage);
        //    nTargetCount++;
        //}

        Invoke("resetProjectilePosition", 0.25f);
        

    }

    void resetProjectilePosition()
    {
        this.gameObject.transform.localPosition = Vector3.zero;
        myTarget = null;
        this.gameObject.SetActive(false);
        mySphereCollider.radius = 0.5f;
        arDetectedEnemy.Clear();
        Debug.Log("arDetectedEnemy cleared.. now:" + arDetectedEnemy.Count);
        CancelInvoke();
    }

}
