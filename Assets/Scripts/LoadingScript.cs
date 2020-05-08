using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    
    public GameObject LoadingScreen;
    public Slider slider;
    public Text progText;
    // Start is called before the first frame update

    public void LoadScene(int indexScene)
    {
        StartCoroutine(LoadASync(indexScene + 1));
    }
    IEnumerator LoadASync(int indexScene)
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(indexScene);
        LoadingScreen.SetActive(true);
        while (!oper.isDone)
        {
            float prog = Mathf.Clamp01(oper.progress / 0.9f);
            slider.value = prog;
            progText.text = prog * 100 + "%";
            yield return null;
        }
    }
}
