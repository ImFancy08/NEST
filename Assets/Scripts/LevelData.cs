using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelData : MonoBehaviour
{
    [SerializeField] public string nextLevel;

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
        //StartCoroutine(GameManager.gm.Load(nextLevel));
    }
}