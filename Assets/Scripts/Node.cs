using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private BuildManager buildManager;
    private TowerBlueprint blueprint;

    private GameObject _tower;
    public GameObject tower
    {
        get { return _tower; }
        set { _tower = value; }
    }

    // Use this for initialization
    void Start()
    {
        tower = null;

        buildManager = BuildManager.instance;
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
