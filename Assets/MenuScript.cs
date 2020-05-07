using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public Text progText;

    public void StartGame(int indexScene)
    {
        StartCoroutine(LoadASync(indexScene + 1));
    }

    IEnumerator LoadASync (int indexScene)
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(indexScene);
        LoadingScreen.SetActive(true);
        while(!oper.isDone)
        {
            float prog = Mathf.Clamp01(oper.progress / 0.9f);
            slider.value = prog;
            progText.text = prog * 100 + "%";
            yield return null;
        }
    }
}
