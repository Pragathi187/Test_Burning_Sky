using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused=false;
    public bool isButtonPressed;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (isButtonPressed)
        {

            if (IsGamePaused)
            {
                Pause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale =1f;
        IsGamePaused = false;

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);

    }

    public void BackButtonClick()
    {
        isButtonPressed = true;
        pauseMenuUI.SetActive(true);
    }
}
