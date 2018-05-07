using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour {

    AsyncOperation async;
    public int mainScene;
    private bool changeScene = true;

    public void ChangeScene()
    {
        if (changeScene)
        {
            StartCoroutine(LoadingTime());
            SceneManager.LoadScene(mainScene);
        }else
        {
            Debug.Log("error while opening the new scene!");
        }
    }


    IEnumerator LoadingTime()
    {
        yield return new WaitForSeconds(3f);

        async = SceneManager.LoadSceneAsync(mainScene);
        async.allowSceneActivation = false;

        while(!async.isDone)
        {
            yield return new WaitForSeconds(2f);
            if (async.isDone)
            {
                async.allowSceneActivation = true;
                SceneManager.LoadScene(mainScene);
            }
            Debug.Log(async.progress);
            yield return null;
        }

    }
}
