using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { NOMAL, SPEED, TANKER, BOSS, MIXED}
public class Enemy : MonoBehaviour, InterFaces.IEnemy
{
    public int maxHealth { get; set; }
    public int currentHealth { get; set; }
    public float moveSpeed { get; set; }
    public int lootGold { get; set; }

    public GameObject[] wayPoints { get; set; }
    protected GameObject wayPointsMother;
    protected int wayPointIndex;
    protected int wayPointIndexSrc;
    protected GameObject currentTargetWayPoint;

    protected EnemyType enemyType;


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
        Vector3 MovingPosition = Vector3.MoveTowards(this.transform.position, movePoint.transform.position, 0.005f * moveSpeed);
        LookAtTargetPoint(MovingPosition);
        this.transform.position = MovingPosition;
    }

    public GameObject SetMovePoint(GameObject[] movePoints)
    {
        wayPointIndex = wayPointIndexSrc % 4;
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

    public void AddWayPointIndex()
    {
        if (Vector3.Distance(currentTargetWayPoint.transform.position, this.transform.position) <= 0)
        {
            wayPointIndexSrc++;
        }
    }
    public void MoveArround()
    {
        currentTargetWayPoint = SetMovePoint(wayPoints);
        MoveToPoint(currentTargetWayPoint);
        AddWayPointIndex();
    }

    public void LookAtTargetPoint(Vector3 targetPoint)
    {
        transform.LookAt(targetPoint);
    }
}

