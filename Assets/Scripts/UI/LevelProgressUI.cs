using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    public Slider slider;
    private float _progress = 0f;

    // Use this for initialization
    void Awake()
    {
        slider.value = _progress;
    }

    // Update is called once per frame
    void Update()
    {
        if (_progress >= WaveSpawner.progressPerc)
            return;

        _progress += Time.deltaTime;
        slider.value = Mathf.Clamp01(_progress);
    }
}
