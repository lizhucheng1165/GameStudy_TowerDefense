using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Renderer rend;
    private Color nodeColor;
    [SerializeField] Color hoverColor;
    private GameObject turret;
    private Vector3 positionOffsetY = new Vector3 (0f, 0.5f, 0f); 
    BuildManager buildManager;

    void Start ()
    {
        rend = GetComponent<Renderer>();
        nodeColor = rend.material.color;

        buildManager = BuildManager.instance;
    }
    void OnMouseEnter()
    {
        if(buildManager.GetTurretToBuild() == null)
        {
            Debug.Log("Exit");
            return;
        }
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = nodeColor;
    }

    void OnMouseDown()
    {
        if(buildManager.GetTurretToBuild() == null) return;
        if(turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(Turret turret)
    {
        if (Resources.playerMoney < turret.cost)
        {
            Debug.Log("Not Enough Money");
            return;
        }
        Resources.SpendMoney(turret.cost);
        GameObject _turret = Instantiate(turret.turretPrefab, transform.position + positionOffsetY, transform.rotation);
    }
}
