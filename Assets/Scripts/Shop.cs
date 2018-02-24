using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;

    public TowerBlueprint turret;
    public TowerBlueprint cannon;

    void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void TaskSelectTurret()
    {
        Debug.Log("Turret selected");
        _buildManager.SelectTowerToBuild(turret);
    }

    public void TaskSelectCannon()
    {
        Debug.Log("Cannon selected");
        _buildManager.SelectTowerToBuild(cannon);
    }
}
