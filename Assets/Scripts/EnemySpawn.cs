using JetBrains.Annotations;
using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
public class EnemySpawn : MonoBehaviour
{
    //public static EnemySpawn enemy;
    [SerializeField] public static int EnemiesAlives = 0;


    //public LevelData data;
    public Wave[] waves; //Number of waves in the game

    [SerializeField] public GameObject StartPoint, endPoint;
    [SerializeField] float timeBetweenWaves = 5f;

    //Time of each wave and time Count down - Decrease in update to count time for spawning next wave
    [SerializeField] float timeCountDown = 2f; 
    private int waveIndex = 0; //Currently Waves in the game


    [SerializeField] public Text waveCountDownText;

    private void Start()
    {
        StartPoint = GameObject.FindGameObjectWithTag("Start Point");

    }
    private void Update()
    {
       CountDown();
    }

    public void CountDown()
    {
        if(EnemiesAlives > 0)
        {
            return;
        }
        if (timeCountDown <= 0)
        {
            StartCoroutine(SpawnWave());
            timeCountDown = timeBetweenWaves;
            return;
        }

        timeCountDown -= Time.deltaTime;
        timeCountDown = Mathf.Max(timeCountDown, 0f); // Thx Keenao

        GameManager.gm.textTime.text = string.Format("{0:00.00}", timeCountDown);//Cut off decimal, leave the first one number, always round
        //waveCountDownText.text = Mathf.Floor(timeCountDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.Count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.Rate);
        }
        waveIndex++;
        if(waveIndex == waves.Length)
        {
            Debug.Log("You Won");
            //data.Win();
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject nAnt = (GameObject) Instantiate(enemy, StartPoint.transform.position, Quaternion.identity);
        nAnt.GetComponent<EnemyMoving>().EndPoint = endPoint.transform;
        EnemiesAlives++;
    }

    internal static void OnEnemyDeath()
    {
        EnemySpawn.EnemiesAlives--;
    }
}
