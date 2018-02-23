using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;

    public TowerBlueprint turret;
    public TowerBlueprint rocketLauncher;

    void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void TaskSelectTurret()
    {
        Debug.Log("Turret selected");
        _buildManager.SelectTowerToBuild(turret);

    }

    public void TaskSelectRocketLauncher()
    {
        Debug.Log("Rocketlauncher selected");
        _buildManager.SelectTowerToBuild(rocketLauncher);
    }
}
