using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private float m_positionX;
    [SerializeField] private float m_positionZ;

    public float positionX { get { return m_positionX; } set { m_positionX = value; } }
    public float positionY { get { return m_positionZ; } set { m_positionZ = value; } }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
