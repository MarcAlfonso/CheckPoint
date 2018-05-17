using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    //public Animation anim;
	// Use this for initialization
	void Start () {
        //anim = GetComponent<Animation>();
		
	}
	
	// Update is called once per frame
	void Update () {
        ClickEnter();
	}

    void ClickEnter()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }



}
