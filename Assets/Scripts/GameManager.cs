using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager gm { get; set; }
    bool GameStart;
    const string firstLevel = "Level1";
    const string menuLevel = "Menu";
    string currentLevelName;
    string previousLevelName;

    private void Awake()
    {
        gm = this;
        GameStart = true;
        Load(firstLevel);
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