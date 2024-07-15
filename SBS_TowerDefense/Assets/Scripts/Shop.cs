using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public Turret standardTurret;
    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        buildManager.SetTurretToBuild(standardTurret);
        Debug.Log("Standard Turret Selected");
    }
}
