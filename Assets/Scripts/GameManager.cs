using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm { get; set; }
    bool GameStart;
    const string firstLevel = "Level1";
    const string menuLevel = "Menu";
    string currentLevelName;
    string previousLevelName;
    //int
    [SerializeField] public int lives, money, levels;

    //text
    public Text textLive;
    public Text textLevel;
    public Text textMoney;
    public Text textTime;

    private void Awake()
    {
        gm = this;
        GameStart = true;
        Load(firstLevel);
    }
    private void Start()
    {
        lives = 20;
        money = 0;
        levels = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        textLive.text = lives.ToString();
        textLevel.text = levels.ToString();
        textMoney.text = money.ToString();
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