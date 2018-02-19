using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private BuildManager buildManager;

    public TowerBlueprint blueprint;

    public GameObject tower;

    // Use this for initialization
    void Start()
    {
        tower = null;

        buildManager = BuildManager.instance;

        buildManager.SelectTowerToBuild(blueprint);
    }

    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;

        if (tower != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        buildManager.BuildTowerOn(this);
    }
}
