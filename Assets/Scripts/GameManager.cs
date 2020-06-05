using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm { get; set; }
    bool GameStart;
    const string firstLevel = "Level1";
    const string menuLevel = "Menu";
    string currentLevelName;
    string previousLevelName;

    private bool gameOver = false;

    //int
    [SerializeField] public int levels;

    //text
    public Text textLive;
    public Text textLevel;
    public Text textTime;

    private void Awake()
    {
        gm = this;
        GameStart = true;
        Load(firstLevel);
    }
    private void Start()
    {
        levels = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        textLevel.text = levels.ToString();
        if(gameOver)
        {
            return;
        }
        if(PlayerStats.Lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        SceneManager.LoadScene(menuLevel);
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