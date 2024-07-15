using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private Turret turretToBuild;
    public GameObject standardTurretPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTurretToBuild(Turret turret)
    {
        turretToBuild = turret;
        Debug.Log("Turret Set");
    }
    public Turret GetTurretToBuild()
    {
        return turretToBuild;
    }
}
