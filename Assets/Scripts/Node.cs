using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public GameObject towerPrefab;
    private GameObject builtTower;

    // Use this for initialization
    void Start()
    {
        builtTower = null;
    }

    void OnMouseDown()
    {
        if (builtTower != null)
        {
            // Show Upgrade menu
            return;
        }

        builtTower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
    }
}
