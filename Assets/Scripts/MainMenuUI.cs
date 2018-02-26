using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void TaskResumeButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void TaskRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void TaskQuitButton()
    {
        Time.timeScale = 0.0f;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
