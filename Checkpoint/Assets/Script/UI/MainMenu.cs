using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using TMPro;

public class MainMenu : MonoBehaviour {

    public Button continueButton, newGameButton, optionsButton;
    public GameData gameData;
    public TextMeshProUGUI text;
    public Sprite buttonDefault;
    void Awake()
    {
        Continue(); //interactable = true + cargamos el Load
    }

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
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
            text.color = new Color(255, 255, 255);
            continueButton.GetComponent<Image>().sprite = buttonDefault;
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
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("GameScene");
    }

    IEnumerator OptionsScene()
    {
        Debug.Log("Going to options scene...");
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("OptionsTest");
    }

    IEnumerator ContinueScene()
    {
        //Debug.Log("Continuing the game...");
        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene("GameScene");
    }
}
