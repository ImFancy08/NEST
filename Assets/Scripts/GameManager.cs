using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] public int numberofEnemy;
    [SerializeField] private Enemy enemy;
    [SerializeField] private int indexScene;
    //LoadingScript load;
    // Start is called before the first frame update
    void Start()
    {
        indexScene = SceneManager.GetActiveScene().buildIndex;
    }
    // Update is called once per frame
    void Update()
    {
        numberofEnemy = GameObject.FindGameObjectsWithTag("Red Ant").Length;
        if (numberofEnemy <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}