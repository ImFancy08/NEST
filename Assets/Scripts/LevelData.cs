using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{
    public static LevelData data;

    public string nextLevel;
    public int nextLevelIndex = 2;

    bool isLevelFinished;

    void Start()
    {
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
    }
    private void Update()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        if (GameManager.gm != null)
        {
            GameManager.gm.CheckGameOver();
        }
        else
        {
            Debug.Log("Enable Main Menu");
            return; 
        }
    }
    public void Win()
    {
        if (isLevelFinished)
        {
            return;
        }
        isLevelFinished = true;
        PlayerPrefs.SetInt("levelWon", nextLevelIndex);
    }

    
}