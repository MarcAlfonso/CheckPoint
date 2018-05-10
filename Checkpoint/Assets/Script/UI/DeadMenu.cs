using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class DeadMenu : MonoBehaviour
{

    public GameObject deadMenu;
    public Button restart, options, exit, loadButton;
    public GameData gameData;
    public TextMeshProUGUI loadText;

    void Awake()
    {
        LoadCheckpoint();
    }

    // Use this for initialization
    void Start()
    {
        loadButton.GetComponent<Button>();
        loadText = GetComponent<TextMeshProUGUI>();
    }

    public void ExitGame()
    {
        StartCoroutine(Exit());
    }

    public void OptionsScene()
    {
        StartCoroutine(Options());
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
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("StartScreen");
    }

    IEnumerator Options()
    {
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("OptionsTest");
    }







}
