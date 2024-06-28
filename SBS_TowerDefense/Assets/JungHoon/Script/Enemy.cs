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

    // Start is called before the first frame update
    void Start()
    {
        fEnemySpeed = 0.1f;
        bShouldMove = true;
        currentInGameManager = GameObject.FindObjectOfType<InGameManager>();
        vec3MoveTargetLocation = currentInGameManager.arrBoardTile[0].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bShouldMove == true)
        {
            moveToTargetLocation(vec3MoveTargetLocation);
        }

        calculateTargetLocationArrive(vec3MoveTargetLocation, out fDistanceToTargetLocation);
        
        if(fDistanceToTargetLocation <= 1.0f)
        {
            bShouldMove = false;
        }

    }

    void moveToTargetLocation(Vector3 vec3MoveTargetLocation)
    {
        this.gameObject.transform.Translate(vec3MoveTargetLocation * Time.deltaTime * fEnemySpeed);
    }

    void calculateTargetLocationArrive(Vector3 vec3MoveTargetLocation, out float fDistanceToTargetLocation)
    {

        fDistanceToTargetLocation = Vector2.Distance(this.gameObject.transform.position, vec3MoveTargetLocation);

    }

    
}
