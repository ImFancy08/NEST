using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public Text progText;
    const string mainScene = "MainScene";

    public void StartGame()
    {
        StartCoroutine(LoadASync());
    }

    IEnumerator LoadASync ()
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(mainScene);
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
