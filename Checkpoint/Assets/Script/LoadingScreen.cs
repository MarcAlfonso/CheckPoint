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

    void Update()
    {
        if (!changeScene)
        {
            NewScene();
        }else
        {
            Debug.Log("Error changing the scene");
        }
    }

    public void NewScene()
    {
        if (!changeScene)
            StartCoroutine(LoadingTime());
        else
            StartCoroutine(LoadingTime());
    }
    

    IEnumerator LoadingTime()
    {
        yield return new WaitForSeconds(8f);
        async = SceneManager.LoadSceneAsync(mainScene);
        async.allowSceneActivation = false;

        while (!async.isDone)
        { 
            loadProgress = async.progress;
            loadProgress += 0.1f;
            if (async.progress == 0.9f)
            {
                //Debug.Log("Cambiando de escena...");
                async.allowSceneActivation = true;
            }
            //Debug.Log(async.progress);
            yield return null;
        }
        Debug.Log("Escena cambiada exitosamente!!");
    }
}
