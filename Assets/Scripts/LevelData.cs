using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{
    [SerializeField] public string nextLevel;

    bool isLevelFinished;

    //Scene scene = SceneManager.GetActiveScene();
    public static bool GameIsOver;

    void Start()
    { 
        GameIsOver = false;
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(firstLevel));
        //Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
    }
    private void Update()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        if (GameIsOver)
        {
            return;
        }
        if (PlayerStats.Lives == 0 || Input.GetKeyDown("e"))
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        GameIsOver = true;
        GameManager.gm.gameOverCanvas.SetActive(true);
        GameManager.gm.mainCanvas.SetActive(false);
    }
    public void Win()
    {
        if (isLevelFinished)
        {
            return;
        }
        isLevelFinished = true;
        StartCoroutine(GameManager.gm.Load(nextLevel));
    }
}