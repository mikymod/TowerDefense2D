using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;

    public TowerBlueprint turret;
    public TowerBlueprint cannon;
    public TowerBlueprint rocketLauncher;

    void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void TaskSelectTurret()
    {
        _buildManager.SelectTowerToBuild(turret);
    }

    public void TaskSelectCannon()
    {
        _buildManager.SelectTowerToBuild(cannon);
    }

    public void TaskSelectRocketLauncher()
    {
        _buildManager.SelectTowerToBuild(rocketLauncher);
    }
}
