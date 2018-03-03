using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastForwardUI : MonoBehaviour
{
    private Toggle forwardToggle;

    void Awake()
    {
        forwardToggle = gameObject.GetComponent<Toggle>();
    }

    public void TaskPerformFastForward()
    {
        if (forwardToggle.isOn)
            Time.timeScale = 2f;
        else
            Time.timeScale = 1f;
    }
}
