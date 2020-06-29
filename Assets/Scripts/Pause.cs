using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseGame;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("p"))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseGame.SetActive(!pauseGame.activeSelf);

        if(pauseGame.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}
