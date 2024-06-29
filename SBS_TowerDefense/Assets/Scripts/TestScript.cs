using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    GameObject testTransform;
    Transform[] testGameObjects;
    Transform[] tempPoints;
    private void Awake()
    {
        tempPoints = new Transform[4];  
        testTransform = GameObject.Find("MovePoints");
        testGameObjects = testTransform.transform.GetComponentsInChildren<Transform>();

        for (int i = 0; i < testGameObjects.Length - 1; i++)
        {
            tempPoints[i] = testGameObjects[i + 1];
        }
        if (testTransform != null)
        {
            foreach (Transform temp in tempPoints)
            {
                print(temp.name);
            }
        }
        else
        {
            print("¾øÀ½");
        }
    }
}
