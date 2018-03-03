using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuUI : MonoBehaviour
{
    public GameObject mainMenu;

    public void TaskOpenMenu()
    {
        Debug.Log("Open Main Menu");
        mainMenu.SetActive(true);

        // Pause game
        Time.timeScale = 0f;
    }
}
