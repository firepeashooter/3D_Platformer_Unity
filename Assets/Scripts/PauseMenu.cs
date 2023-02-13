using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//This class deals with the pause menu


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI; //links the pause menu game object
    

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape)) 
       {
        if (GameIsPaused)
        {
            Resume();
        }else
        {
            Pause();
        }
       }
    }


    public void Resume()
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
        SceneManager.LoadScene("Start Screen 1");
    }

    public void QuitGame()
    {
        Application.Quit();
        
    }

}
