using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool Pausable = false;

    public GameObject PauseMenuUI;
    public GameObject OptionsMenuUI;
    public GameObject Background;
    
    // Update is called once per frame
    void Update()
    {
        if (Pausable && Input.GetKeyDown(KeyCode.Escape))
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

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(false);
        Background.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Background.SetActive(true);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Title Scene");
        Time.timeScale = 1f;
        GameIsPaused = false;
        Background.SetActive(false);
    }
}
