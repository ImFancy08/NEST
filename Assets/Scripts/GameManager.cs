using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm { get; set; }
    const string firstLevel = "Level1";
    const string menuLevel = "Menu";
    string currentLevelName;
    string previousLevelName;

    AsyncOperation async;

    public GameObject gameOverCanvas;
    public GameObject mainCanvas;

    //int
    [SerializeField] public int levels;

    //text
    public Text textLive;
    public Text textLevel;
    public Text textTime;

    private void Awake()
    {
        LevelData.GameIsOver = false;
    }
    private void Start()
    {
        StartCoroutine(Load(firstLevel));
        gm = this;
    }


    private void Update()
    {
        textLevel.text = levels.ToString();
    }


    public IEnumerator Load(string sceneName)
    {
        if (!string.IsNullOrWhiteSpace(sceneName))
        {
            previousLevelName = currentLevelName;
            Unload();

            // If there's a name then its a level
            currentLevelName = sceneName;
            var loading = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            yield return loading;
            var scene = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(scene);
        }
        else
        {
            // Otherwise return to menu
            SceneManager.LoadScene(menuLevel); 
        }
    }

    public void Unload()
    {
        if (!string.IsNullOrWhiteSpace(previousLevelName))
        {
            SceneManager.UnloadSceneAsync(previousLevelName);
        }
    }

 }