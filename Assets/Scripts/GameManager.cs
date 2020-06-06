using System;
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

    public GameObject gameOverCanvas;
    public GameObject mainCanvas;

    public static bool GameIsOver;

    //int
    [SerializeField] public int levels;

    //text
    public Text textLive;
    public Text textLevel;
    public Text textTime;

    private void Awake()
    {
        gm = this;
        GameIsOver = false;
        Load(firstLevel);
    }
    private void Start()
    {
        levels = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        textLevel.text = levels.ToString();
        if(GameIsOver)
        {
            return;
        }
        if(PlayerStats.Lives <= 0 || Input.GetKeyDown("e"))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GameIsOver = true;
        gameOverCanvas.SetActive(true);
        mainCanvas.SetActive(false); 
    }

    public void Load(string sceneName)
    {
        if (!string.IsNullOrWhiteSpace(sceneName))
        {
            previousLevelName = currentLevelName;
            Unload();

            // If there's a name then its a level
            currentLevelName = sceneName;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive); 
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