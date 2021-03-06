﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    private int _waveIndex = 0;

    static private int _progressMaxLevel = 0;
    static private int _progressLevel = 0;

    static public float progressPerc
    {
        get { return (float)_progressLevel / (float)_progressMaxLevel; }
    }

    private float _countdown;

    private Transform _spawn;

    public float _range = 1f;

    void Start()
    {
        foreach (Wave wave in waves)
            _progressMaxLevel += wave.numEnemy;

        _countdown = waves[_waveIndex].delay;

        _spawn = GetComponentInParent<Transform>();
    }

    void Update()
    {
        if (_waveIndex > waves.Length - 1)
            return; // End Level

        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = waves[_waveIndex].delay;
            Player.Round++;
        }

        _countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[_waveIndex];
        for (int i = 0; i < wave.numEnemy; i++)
        {
            float offsetX = Random.Range(-_range * 0.5f, _range * 0.5f);
            float offsetY = Random.Range(-_range * 0.5f, _range * 0.5f);
            Vector3 curPos = _spawn.position;
            curPos.x += offsetX;
            curPos.y += offsetY;

            Instantiate(wave.enemyPrefab, curPos, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        _progressLevel += wave.numEnemy;
        _waveIndex++;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(255f, 0f, 0f, 255f);
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
