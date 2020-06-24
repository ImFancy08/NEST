using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm { get; set; }
    public static bool GameIsOver;

    [Header("UI FIELD")]
    public Text textLive;
    public Text textLevel;
    public Text textTime;
    public GameObject gameOverCanvas;
    public GameObject mainCanvas;
    public GameObject wonCanvas;

    [Header("NON TOUCHABLE")]
    public string levelName;
    const string menuLevel = "Menu";
    string currentLevelName;
    string previousLevelName;
    //text
    

    private void Awake()
    {
        GameIsOver = false;
        levelName = MenuScript.sceneName;
    }
    private void Start()
    {
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
        StartCoroutine(Load(levelName));
        gm = this;
    }


    private void Update()
    {
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

    public void GameOver()
    {
        GameIsOver = true;
        EnemySpawn.EnemiesAlives = 0;
        gameOverCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void WonDisplay()
    {
        EnemySpawn.EnemiesAlives = 0;
        wonCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void CheckGameOver()
    {
        if (GameIsOver)
        {
            return;
        }
        if (PlayerStats.Lives <= 0 || Input.GetKeyDown("e"))
        {
            GameOver();
        }
    }
}