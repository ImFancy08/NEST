using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject selectLevelPanel;
    public GameObject menuPanel;

    public Slider slider;
    public Text progText;
    const string mainScene = "MainScene";

    public static string sceneName;

    public void SceneSelection()
    {
        menuPanel.SetActive(false);
        selectLevelPanel.SetActive(true);
    }

    public void GoBackMenu()
    {
        menuPanel.SetActive(true);
        selectLevelPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame(string sceneSelection)
    {
        //GameManager.GameIsOver = false;
        StartCoroutine(LoadASync());
        sceneName = sceneSelection;
    }

    IEnumerator LoadASync ()
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync(mainScene);
        selectLevelPanel.SetActive(false);
        loadingScreen.SetActive(true);
        while(!oper.isDone)
        {
            float prog = Mathf.Clamp01(oper.progress / 0.9f);
            slider.value = prog;
            progText.text = prog * 100 + "%";
            yield return null;
        }
    }

    public void DeletePlayPref()
    {
        PlayerPrefs.DeleteAll();
    }
}
