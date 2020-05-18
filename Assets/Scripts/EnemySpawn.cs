using JetBrains.Annotations;
using System.Collections;

using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
public class EnemySpawn : MonoBehaviour
{
    //public static EnemySpawn enemy;
    [SerializeField] public static int EnemiesAlives = 0;

    public Wave[] waves;

    [SerializeField] public GameObject StartPoint, endPoint;
    [SerializeField] public float timeBetweenWaves = 5f, timeCountDown = 2f; //Time of each wave and time Count down - Decrease in update to count time for spawning next wave
    [SerializeField] private int waveIndex = 0;//Number of waves in the level

    //[SerializeField] public Text waveCountDownText;

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
        timeCountDown = Mathf.Clamp(timeCountDown, 0f, Mathf.Infinity);

        //waveCountDownText.text = string.Format("{0:00.00}", countdown);//Cut off decimal, leave the first one number, always round

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
    }

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject nAnt = (GameObject) Instantiate(enemy, StartPoint.transform.position, Quaternion.identity);
        nAnt.GetComponent<EnemyMoving>().EndPoint = endPoint.transform;
        EnemiesAlives++;
    }
}
