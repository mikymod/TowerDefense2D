using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject standardTurretPrefab;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene");
        }

        instance = this;
    }

    private TowerBlueprint towerToBuild;
    private Node selectedNode;

    public bool CanBuild
    {
        get { return towerToBuild != null; }
    }

    public bool HasMoney
    {
        get { return Player.Money >= towerToBuild.cost; }
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
    }

    public void DeselectNode()
    {
        selectedNode = null;
    }

    public void SelectTowerToBuild(TowerBlueprint blueprint)
    {
        towerToBuild = blueprint;

        DeselectNode();
    }

    public void BuildTowerOn(Node node)
    {
        if (!CanBuild)
            return;

        if (!HasMoney)
            Debug.Log("You don't have enough money");

        Player.Money -= towerToBuild.cost;
        Debug.Log("Player money: " + Player.Money);
        GameObject tower = Instantiate(towerToBuild.prefab, node.transform.position, Quaternion.identity);
        node.tower = tower;
    }
}
