using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject LoadingScreen;
    public void StartGame(int indexScene)
    {
        StartCoroutine(LoadASync(indexScene + 1));
    }

    IEnumerator LoadASync (int indexScene)
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(indexScene);
        while(!oper.isDone)
        {
            float prog = Mathf.Clamp01(oper.progress / 0.9f);
            Debug.Log(prog);
            yield return null;
        }
    }
}
