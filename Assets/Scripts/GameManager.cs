using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager gm { get; set; }
    bool GameStart;
    private void Awake()
    {
        gm = this;
        GameStart = true;
        Load(2);
        //Load(3);
        //Load(4);
    }
 
    public void Load(int sceneIndex)
    {
        if(!SceneManager.GetSceneByBuildIndex(sceneIndex).isLoaded)
        {
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
        }
    }
    public void Unload(int sceneIndex)
    {
        if (SceneManager.GetSceneByBuildIndex(sceneIndex).isLoaded)
        {
            SceneManager.UnloadScene(sceneIndex);
        }
    }
}