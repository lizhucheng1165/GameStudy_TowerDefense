using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private int m_positionX;
    [SerializeField] private int m_positionZ;
    [SerializeField] private bool m_isBuildable;
    [SerializeField] private bool m_isSpawnable;

    public int positionX { get {return m_positionX; } set { m_positionX = value; } }
    public int positionZ { get {return m_positionZ; } set { m_positionZ = value; } }
    public bool isBuildable { get { return m_isBuildable; } set { m_isBuildable = value; } }
    public bool isSpawnable { get { return m_isSpawnable; } set { m_isSpawnable = value; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
