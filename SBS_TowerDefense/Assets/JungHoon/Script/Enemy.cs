using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Vector3 vec3MoveTargetLocation;
    [SerializeField] InGameManager currentInGameManager;
    [SerializeField] UIManager currentUIManager;
    float fEnemySpeed;
    float fDistanceToTargetLocation;
    bool bShouldMove;
    Vector3 vec3MoveVector;
    Vector3 vec3EnemyStartLocation;
    [SerializeField] List<GameObject> targetLocationList;
    int nTargetLocationIndex;
    [SerializeField] float fCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        fCurrentHealth = 2.0f;
        fEnemySpeed = 0.2f;
        bShouldMove = true;
        nTargetLocationIndex = 0;
        currentInGameManager = GameObject.FindObjectOfType<InGameManager>();
        vec3EnemyStartLocation = currentInGameManager.arrBoardTile[42].transform.position;
        vec3MoveTargetLocation = vec3EnemyStartLocation;
        vec3MoveVector = vec3MoveTargetLocation - this.gameObject.transform.position;

        addEnemyTargetLocationList();

        currentUIManager = GameObject.FindObjectOfType<UIManager>();
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
            nTargetLocationIndex++;

            if(nTargetLocationIndex >= 4)
            {
                nTargetLocationIndex = 0;
            }

            Vector3 vector3Next = targetLocationList[nTargetLocationIndex].transform.position;
            changeTargetLocation(vector3Next);
        }

    }

    public void minusMyHealth(float fDamage)
    {
        fCurrentHealth -= fDamage;
        if(fCurrentHealth <= 0f)
        {
            destroyCurrentEnemy();
        }
    }

    public void destroyCurrentEnemy()
    {
        currentInGameManager.addCurrentGold(10);
        currentUIManager.updateCurrentGoldStat();
        currentInGameManager.addEnemyKilled();
        currentUIManager.updateCurrentEnemyKilled();
        currentInGameManager.minusLeftEnemyCount();
        Destroy(this.gameObject);
    }

    void moveToTargetLocation(Vector3 vec3MoveVector)
    {
        this.gameObject.transform.position += new Vector3(vec3MoveVector.x * Time.deltaTime * fEnemySpeed, vec3MoveVector.y * Time.deltaTime * fEnemySpeed, 0f);
    }

    void calculateTargetLocationArrive(Vector3 vec3MoveTargetLocation, out float fDistanceToTargetLocation)
    {

        fDistanceToTargetLocation = Vector2.Distance(this.gameObject.transform.position, vec3MoveTargetLocation);

    }

    void changeTargetLocation(Vector3 vec3NextLocation)
    {
        vec3MoveTargetLocation = vec3NextLocation;
        vec3MoveVector = vec3MoveTargetLocation - this.gameObject.transform.position;
    }

    void addEnemyTargetLocationList()
    {
        targetLocationList.Add(currentInGameManager.arrBoardTile[42]);
        targetLocationList.Add(currentInGameManager.arrBoardTile[48]);
        targetLocationList.Add(currentInGameManager.arrBoardTile[6]);
        targetLocationList.Add(currentInGameManager.arrBoardTile[0]);
    }
    
}
