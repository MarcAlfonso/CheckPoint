using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class DeadMenu : MonoBehaviour
{

    public GameObject deadMenu, optionsMenu, pauseMenu;
    public Button restart, options, exit, loadButton;
    public GameData gameData;
    public TextMeshProUGUI loadText;

    void Awake()
    {
        LoadCheckpoint();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.SetActive(false);
        }
    }

    // Use this for initialization
    void Start()
    {
        loadButton.GetComponent<Button>();
        loadText = GetComponent<TextMeshProUGUI>();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadCheckpoint()
    {
        if (File.Exists(gameData.path))
        {
            loadButton.interactable = true;
            loadText.color = new Color(255, 255, 255);
        }
    }

    public void LoadLevel()
    {
        gameData.LoadGame();
        deadMenu.SetActive(false);
    }

    








}
