using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] public int numberofEnemy;
    [SerializeField] private Enemy enemy;
    [SerializeField] private int indexScene;
    private Boolean isValid = true;
    //LoadingScript load;
    // Start is called before the first frame update
    void Start()
    {
        indexScene = SceneManager.GetActiveScene().buildIndex; //Get the index of the current Scene
        Debug.Log(indexScene);
        Debug.Log(SceneManager.sceneCountInBuildSettings);
    }
    // Update is called once per frame
    void Update()
    {
        Win();
    }
    public void Win()
    {
        numberofEnemy = GameObject.FindGameObjectsWithTag("Red Ant").Length;
        Debug.Log("Enemy:" + numberofEnemy);
        if (numberofEnemy == 0)
        {
            if (indexScene +1 < SceneManager.sceneCountInBuildSettings)// 3 + 1 != 4 is false
            {                                                           
                SceneManager.LoadScene(indexScene + 1);
            }
            else                                      
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}