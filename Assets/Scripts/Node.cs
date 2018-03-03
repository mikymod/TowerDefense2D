using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private BuildManager _buildManager;
    private TowerBlueprint _blueprint;

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

        _buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (!_buildManager.CanBuild)
            return;

        if (tower != null)
        {
            _buildManager.SelectNode(this);
            return;
        }

        _buildManager.BuildTowerOn(this);
    }
}
