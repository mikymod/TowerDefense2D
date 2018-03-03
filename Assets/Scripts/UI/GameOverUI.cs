using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public Text waveText;

    void Awake()
    {
        waveText.text = "Wave: " + Player.Round;
    }

    public void TaskRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void TaskQuit()
    {
        Application.Quit();
    }

}
