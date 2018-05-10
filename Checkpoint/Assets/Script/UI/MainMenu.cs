using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;

public class MainMenu : MonoBehaviour {

    public Button continueButton, newGameButton, optionsButton;
    public GameData gameData;


    void Awake()
    {
        Continue(); //interactable = true + cargamos el Load
    }

    void Start()
    {
        //continueButton = GetComponent<Button>();
        //gameData = FindObjectOfType
    }


    public void NewGame()
    {
        StartCoroutine(NewGameScene());
    }

    public void Options()
    {
        StartCoroutine(OptionsScene());
    }

    public void Continue()
    {
        if (File.Exists(gameData.path))
        {
            continueButton.interactable = true;
            gameData.LoadGame();
        }
        else
            Debug.Log("The file doesnt exists!");
    }

    public void ContinueGame()
    {
        StartCoroutine(ContinueScene());
    }
    IEnumerator NewGameScene()
    {
        Debug.Log("Going to game scene...");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameScene");
    }

    IEnumerator OptionsScene()
    {
        Debug.Log("Going to options scene...");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("OptionsTest");
    }

    IEnumerator ContinueScene()
    {
        //Debug.Log("Continuing the game...");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameScene");
    }
}
