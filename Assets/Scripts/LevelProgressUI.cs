using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
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
        // FIXME: Test code. It should interact with an improved WaveSpawner
        progress += Time.deltaTime;
        if (progress >= 1f)
            progress = 0f;

        slider.value = Mathf.Clamp01(progress);
    }
}
