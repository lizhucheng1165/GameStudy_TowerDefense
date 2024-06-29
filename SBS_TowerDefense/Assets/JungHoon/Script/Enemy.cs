using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Vector3 vec3MoveTargetLocation;
    InGameManager currentInGameManager;
    float fEnemySpeed;
    float fDistanceToTargetLocation;
    bool bShouldMove;
    Vector3 vec3MoveVector;

    // Start is called before the first frame update
    void Start()
    {
        fEnemySpeed = 0.5f;
        bShouldMove = true;
        currentInGameManager = GameObject.FindObjectOfType<InGameManager>();
        vec3MoveTargetLocation = currentInGameManager.arrBoardTile[0].transform.position;
        vec3MoveVector = vec3MoveTargetLocation - this.gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (bShouldMove == true)
        {
            moveToTargetLocation(vec3MoveVector);
        }

        calculateTargetLocationArrive(vec3MoveTargetLocation, out fDistanceToTargetLocation);

        if (fDistanceToTargetLocation <= 1.0f)
        {
            bShouldMove = false;
        }

        if (bShouldMove == false)
        {
            Vector3 vector3Next = currentInGameManager.arrBoardTile[42].transform.position;
            changeTargetLocation(vector3Next);
            bShouldMove = true;
        }

    }

    void moveToTargetLocation(Vector3 vec3MoveVector)
    {
        //this.gameObject.transform.Translate(vec3MoveTargetLocation * Time.deltaTime * fEnemySpeed);
        this.gameObject.transform.position += new Vector3(vec3MoveVector.x * Time.deltaTime * fEnemySpeed, vec3MoveVector.y * Time.deltaTime * fEnemySpeed, 0f);
    }

    void calculateTargetLocationArrive(Vector3 vec3MoveTargetLocation, out float fDistanceToTargetLocation)
    {

        fDistanceToTargetLocation = Vector2.Distance(this.gameObject.transform.position, vec3MoveTargetLocation);
        Debug.Log(fDistanceToTargetLocation);

    }

    void changeTargetLocation(Vector3 vec3NextLocation)
    {
        vec3MoveTargetLocation = vec3NextLocation;
        vec3MoveVector = vec3MoveTargetLocation - this.gameObject.transform.position;
    }

    
}
