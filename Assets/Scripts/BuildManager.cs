using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
        }

        instance = this;
    }

    private TowerBlueprint _towerToBuild;
    private Node _selectedNode;

    public bool CanBuild
    {
        get { return _towerToBuild != null; }
    }

    public bool HasMoney
    {
        get { return Player.Money >= _towerToBuild.cost; }
    }

    public void SelectNode(Node node)
    {
        if (_selectedNode == node)
        {
            DeselectNode();
            return;
        }

        _selectedNode = node;
    }

    public void DeselectNode()
    {
        _selectedNode = null;
    }

    public void SelectTowerToBuild(TowerBlueprint blueprint)
    {
        _towerToBuild = blueprint;

        DeselectNode();
    }

    public void BuildTowerOn(Node node)
    {
        if (!CanBuild)
        {
            Debug.Log("You have to select a tower blueprint!");
            return;
        }

        if (!HasMoney)
        {
            Debug.Log("You don't have enough money!");
            return;
        }

        Player.Money -= _towerToBuild.cost;
        Debug.Log("Player money: " + Player.Money);
        GameObject tower = Instantiate(_towerToBuild.prefab, node.transform.position, Quaternion.identity);
        node.tower = tower;
    }
}
