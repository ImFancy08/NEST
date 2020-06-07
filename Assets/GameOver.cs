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

    public void Retry()
    {
        GameManager.gm.GameRestart();
    }   
    
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
