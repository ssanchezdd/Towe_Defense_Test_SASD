using UnityEngine;

public class BuildManager_S : MonoBehaviour
{
    public static BuildManager_S instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one build manager in scene!");
        }
        instance = this;
        
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherTurrentPrefab;

    private TurretBlueprint_S turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectTurretToBuild(TurretBlueprint_S turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node_S node)
    {
        if (PlayerStats_S.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that one sir!");
            return;
        }

        PlayerStats_S.money -= turretToBuild.cost;

        GameObject turret= Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build sir! This is the money that's left: " + PlayerStats_S.money);
    }

}
