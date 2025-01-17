﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Debug.Log("Exitting game...");
        Application.Quit();
    }

    public void SaveGame()
    {
        Time.timeScale = 1f;
        FindObjectOfType<PlayerPosition>().SavePlayer();
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;

    }

    public void LoadGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        FindObjectOfType<PlayerPosition>().LoadPlayer();
        GameIsPaused = false;
    }
}
