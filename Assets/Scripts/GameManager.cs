using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm { get; set; }
    public string levelName;
    const string menuLevel = "Menu";
    string currentLevelName;
    string previousLevelName;
    public static bool GameIsOver;

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
        textLevel.text = levels.ToString();
    }


    public IEnumerator Load(string sceneName)
    {
        if (!string.IsNullOrWhiteSpace(sceneName))
        {
            //GameIsOver = false;
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
        EnemySpawn.enemiesToKill = 0;
        GameManager.gm.gameOverCanvas.SetActive(true);
        GameManager.gm.mainCanvas.SetActive(false);
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