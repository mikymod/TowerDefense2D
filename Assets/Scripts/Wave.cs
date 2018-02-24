using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int numEnemy;
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float delay;
}