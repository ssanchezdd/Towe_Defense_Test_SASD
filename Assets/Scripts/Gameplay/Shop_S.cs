using UnityEngine;

public class Shop_S : MonoBehaviour
{
    public TurretBlueprint_S standardTurret;
    public TurretBlueprint_S missileLauncherTurret;
    public TurretBlueprint_S laserBeamerTurret;

    BuildManager_S buildManager_S;
    private void Start()
    {
        buildManager_S = BuildManager_S.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Buy an standard turret");
        buildManager_S.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncherTurret()
    {
        Debug.Log("There goes a missile launcher kind of turret");
        buildManager_S.SelectTurretToBuild(missileLauncherTurret);
    }

    public void SelectLaserBeamerTurret()
    {
        Debug.Log("There goes a missile launcher kind of turret");
        buildManager_S.SelectTurretToBuild(laserBeamerTurret);
    }
}
