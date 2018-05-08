using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Button continueButton, newGameButton, optionsButton;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        StartCoroutine(NewGameScene());
    }

    public void Options()
    {
        StartCoroutine(OptionsScene());
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
}
