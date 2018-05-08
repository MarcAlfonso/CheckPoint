using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public Button resumeButton, optionsButton, exitButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Exit()
    {
        StartCoroutine(ExitScene());
    }

    IEnumerator ExitScene()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Saliendo del juego...");
        SceneManager.LoadScene("StartScreen");
    }
}
