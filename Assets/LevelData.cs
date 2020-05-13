using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] public int numberofEnemy;
    [SerializeField] public string nextLevel;

    bool isLevelFinished;

    void Update()
    {
        Win();
    }

    public void Win()
    {
        if (isLevelFinished)
        {
            return;
        }

        numberofEnemy = GameObject.FindGameObjectsWithTag("Red Ant").Length;
        if (numberofEnemy == 0)
        {
            isLevelFinished = true;
            GameManager.gm.Load(nextLevel);
        }
    }
}
