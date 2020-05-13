using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{
    [SerializeField] public int numberofEnemy;
    [SerializeField] public int loadScene;
    [SerializeField] public int unloadScene;
    GameManager gm;
  
    void Start()
    {
       
    }
    //Update is called once per frame
    void Update()
    {
        Win();
    }
    public void Win()
    {
        numberofEnemy = GameObject.FindGameObjectsWithTag("Red Ant").Length;
        if (numberofEnemy == 0)
        {
            //Debug.Log("This is " + SceneManager.GetActiveScene().buildIndex);
            //Debug.Log("Works");
            gm.Load(loadScene);
        }
        //if(numberofEnemy == 0)
        //{
        //    StartCoroutine("UnloadScene");
        //}
    }

    IEnumerable UnloadScene()
    {
        yield return new WaitForSeconds(.1f);
        gm.Unload(unloadScene);
    }
}
