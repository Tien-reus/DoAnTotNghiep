using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    /*public GameObject LeftStick;
    public GameObject ButtonSouth;*/


    void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    private void FixedUpdate()
    {
        if (GameIsPaused)
        {
            buttonPress();
        }
        
    }

    public void buttonPress()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        /*LeftStick.SetActive(true);
        ButtonSouth.SetActive(true);*/
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        /*LeftStick.SetActive(false);
        ButtonSouth.SetActive(false);*/
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
    }

}
