using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public Text wavesText;

    private void OnEnable()
    {
        wavesText.text = PlayerStats.WavesCount.ToString();
    }
    
    public void Menu()
    { 
    //    GameManager.GameIsOver = true;
        SceneManager.LoadScene("Menu");
    }
}
