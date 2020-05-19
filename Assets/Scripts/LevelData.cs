using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] public int numberofEnemy;
    [SerializeField] public string nextLevel;

    bool isLevelFinished;
    void Start()
    {
        numberofEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    void Update()
    {
    }

    public void Win()
    {
        if (isLevelFinished)
        {
            return;
        }
            isLevelFinished = true;
            GameManager.gm.Load(nextLevel);
        
    }

}
