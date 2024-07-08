using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMaker : MonoBehaviour
{
    BoxCollider boxCollider;
    RectTransform rectTransform;
    void Start()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        rectTransform = GetComponent<RectTransform>();
        boxCollider.size = rectTransform.sizeDelta;
        boxCollider.center = new Vector3(rectTransform.sizeDelta.x / -2, rectTransform.sizeDelta.y / 2, 0);
    }

    
}