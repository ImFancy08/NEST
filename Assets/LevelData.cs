using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] public int numberofEnemy;
    [SerializeField] public string nextLevel;

    bool isLevelFinished;
    void Start()
    {
        numberofEnemy = GameObject.FindGameObjectsWithTag("Red Ant").Length;
    }
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

        if (numberofEnemy == 0)
        {
            isLevelFinished = true;
            GameManager.gm.Load(nextLevel);
        }
    }

}
