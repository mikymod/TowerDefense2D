using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    public WaveSpawner waveSpawner;
    public Slider slider;
    private float progress = 0f;

    // Use this for initialization
    void Start()
    {
        slider.value = progress;
    }

    // Update is called once per frame
    void Update()
    {
        if (progress >= waveSpawner.progressPerc)
            return;

        progress += Time.deltaTime;
        slider.value = Mathf.Clamp01(progress);
    }
}
