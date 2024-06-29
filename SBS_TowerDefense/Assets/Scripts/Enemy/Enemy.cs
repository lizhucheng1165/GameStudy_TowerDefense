using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, InterFaces.IEnemy
{
    public int maxHealth { get; set; }
    public int currentHealth { get; set; }
    public float moveSpeed { get; set; }
    public int lootGold { get; set; }
    public GameObject[] wayPoints { get; set; }
    private GameObject wayPointsMother;
    private int wayPointIndex;
    public int wayPointIndexSrc;


    private void Awake()
    {
        wayPointIndex = wayPointIndexSrc % 4;


    }
    private void Update()
    {
        
    }
    public void GiveMoney(int lootGold)
    {

    }

    public void InitializeStatus(int waveCount)
    {
        
    }

    public void GetWayPointsList()
    {
        wayPoints = new GameObject[4];
        wayPointsMother = GameObject.Find("MovePoints");
        Transform[] transforms = wayPointsMother.transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = transforms[i + 1].gameObject;
        }
    }
    public void MoveToPoint(GameObject movePoint)
    {
        this.transform.Translate(movePoint.transform.position);
    }

    public GameObject SetMovePoint(GameObject[] movePoints)
    {
        switch (wayPointIndex)
        {
            case 0:
                return movePoints[0];
            case 1:
                return movePoints[1];
            case 2:
                return movePoints[2];
            case 3:
                return movePoints[3];
            default:
                print("movePoints¿À·ù");
                return null;
        }

    }

    
}

