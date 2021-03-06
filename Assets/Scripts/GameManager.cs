﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm { get; set; }
    public static bool GameIsOver;

    AudioSource audioSource;
    public AudioClip wonSound;
    public AudioClip lostSound;

    [Header("UI FIELD")]
    public Text textLive;
    public Text textLevel;
    public Text textTime;
    public Text textWaves;
    public GameObject gameOverCanvas;
    public GameObject buildCanvas;
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
        audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine(Load(levelName));
        gm = this;
    }


    private void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            buildCanvas.SetActive(!buildCanvas.activeSelf);
        }
        textWaves.text = PlayerStats.WavesCount.ToString();
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
        audioSource.clip = lostSound;
        audioSource.Play();
        gameOverCanvas.SetActive(true);
        buildCanvas.SetActive(false);
    }

    public void WonDisplay()
    {
        audioSource.clip = wonSound;
        audioSource.Play();
        EnemySpawn.EnemiesAlives = 0;
        wonCanvas.SetActive(true);
        buildCanvas.SetActive(false);
    }

    public void CheckGameOver()
    {
        if (GameIsOver)
        {
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            GameOver();
        }
    }

}