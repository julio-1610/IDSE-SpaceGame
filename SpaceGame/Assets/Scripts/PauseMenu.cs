using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PausePanel;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Continue();
            } else{
                Pause();
            }
        }
        
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = false;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}

