using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject myParentGameObject;
    public GameObject myTarget;
    Vector3 vec3MoveVector;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(myTarget != null)
        {
            moveToTarget();
        }
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
        if (other.CompareTag("Enemy") == true)
        {
            this.gameObject.transform.localPosition = Vector3.zero;
            myTarget = null;
            this.gameObject.SetActive(false);

            other.gameObject.GetComponent<Enemy>().destroyCurrentEnemy();
            
        }
    }
}
