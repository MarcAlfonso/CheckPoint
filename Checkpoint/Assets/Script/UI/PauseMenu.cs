using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    public Button resumeButton, optionsButton, exitButton;
    public GameObject pauseMenu, optionsMenu;
    private bool paused = false, onOptionsMenu = false;

    void Update()
    {
        PauseGame();
        OptionsMenu();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P) && !paused)
        {
            pauseMenu.SetActive(true);
            if (Time.timeScale == 1) //si no esta pausado
                Time.timeScale = 0;  //lo pausamos
            else
                Time.timeScale = 1; //sino, seguimos el juego

            paused = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && paused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void OptionsMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !onOptionsMenu)
        {
            optionsMenu.SetActive(true);
            onOptionsMenu = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && onOptionsMenu)
        {
            optionsMenu.SetActive(false);
            onOptionsMenu = false;
        }
    }

}
