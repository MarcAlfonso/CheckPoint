using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour
{

    AsyncOperation async;
    public int mainScene;
    private bool changeScene = false;
    private float loadProgress = 0f;
    //  public int loadTime;

    void Update()
    {
        if (!changeScene)
            NewScene();
        else
            Debug.Log("Error changing the scene");
    }

    public void NewScene()
    {
        if (!changeScene)
            LoadingTime();
    }


    void LoadingTime()
    {
        /*async = SceneManager.LoadSceneAsync(mainScene);
        async.allowSceneActivation = false;

        while (!async.isDone)
        { 
            loadProgress = async.progress;
            loadProgress += 0.1f;
            if (async.progress == 0.9f)
            {
                async.allowSceneActivation = true;
            }
        }
        Debug.Log("Escena cambiada exitosamente!!");
    }*/
    }
}
