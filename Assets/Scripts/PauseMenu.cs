using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //References
    public GameObject pauseMenu;

    //Variables
    public bool pauseActive;

    void Update()
    {
        TogglePause();
    }

    void TogglePause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseActive)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pauseActive = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        pauseActive = true;
    }
}
