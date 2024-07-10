using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    [SerializeField] private Tower m_tower;
    [SerializeField] private int m_positionX;
    [SerializeField] private int m_positionZ;
    [SerializeField] private bool m_isBuildable;
    [SerializeField] private bool m_isSpawnable;
    private bool m_isCliecked;

    public Tower tower { get { return m_tower; } set { m_tower = value; } }
    public int positionX { get {return m_positionX; } set { m_positionX = value; } }
    public int positionZ { get {return m_positionZ; } set { m_positionZ = value; } }
    public bool isBuildable { get { return m_isBuildable; } set { m_isBuildable = value; } }
    public bool isSpawnable { get { return m_isSpawnable; } set { m_isSpawnable = value; } }
    public bool isCliecked { get { return m_isCliecked; } set { m_isCliecked = value; } }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        if (!m_isSpawnable && m_isBuildable && !m_isCliecked)
        {
            this.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Material_Tile_Buildable_Hover");
        }
    }

    private void OnMouseExit()
    {
        if (!m_isSpawnable && m_isBuildable && !m_isCliecked)
        {
            this.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Material_Tile_Buildable");
        }
    }
}
