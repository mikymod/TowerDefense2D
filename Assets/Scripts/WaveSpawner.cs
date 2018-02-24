using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private float countdown;

    public Wave[] waves;
    private int waveIndex = 0;

    private int _progressMaxLevel = 0;

    private int _progressLevel = 0;
    public int progressLevel
    {
        get { return _progressLevel; }
    }

    public float progressPerc
    {
        get { return (float)_progressLevel / (float)_progressMaxLevel; }
    }

    void Start()
    {
        foreach (Wave wave in waves)
            _progressMaxLevel += wave.numEnemy;

        countdown = waves[waveIndex].delay;
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
            Instantiate(wave.enemyPrefab, wave.spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        _progressLevel += wave.numEnemy;
        waveIndex++;
    }
}
