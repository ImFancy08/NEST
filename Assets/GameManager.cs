using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    LoadingScript load;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        if (enemy.numberofEnemy <= 0)
        {
            load.LoadScene(indexScene);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
