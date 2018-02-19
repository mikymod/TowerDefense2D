using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FIXME: very basic spawner
public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float startCountdown = 2f;
    public float waveCountdown = 5f;

    private float countdown;
    private float waveCounter = 1;

    void Start()
    {
        countdown = startCountdown;
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = waveCountdown;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveCounter; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        waveCounter++;
    }
}
