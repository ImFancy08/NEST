using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{
    public static LevelData data;

    public string nextLevel;
    public int nextLevelIndex = 2;

    //bool isLevelFinished;

    void Start()
    {

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
        Debug.Log("You Won");
        PlayerPrefs.SetInt("levelWon", nextLevelIndex);
        GameManager.gm.WonDisplay();
    }   
}