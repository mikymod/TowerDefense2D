using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    private int waveIndex = 0;

    static private int _progressMaxLevel = 0;
    static private int _progressLevel = 0;

    static public float progressPerc
    {
        get { return (float)_progressLevel / (float)_progressMaxLevel; }
    }

    private float countdown;

    private Transform _spawn;

    public float _range = 1f;

    void Start()
    {
        foreach (Wave wave in waves)
            _progressMaxLevel += wave.numEnemy;

        countdown = waves[waveIndex].delay;

        _spawn = GetComponentInParent<Transform>();
    }

    void Update()
    {
        if (waveIndex > waves.Length - 1)
            return; // End Level

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = waves[waveIndex].delay;
            Player.Round++;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.numEnemy; i++)
        {
            Instantiate(wave.enemyPrefab, _spawn.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        _progressLevel += wave.numEnemy;
        waveIndex++;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255f, 0f, 0f, 255f);
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
