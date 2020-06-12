using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class EnemySpawn : MonoBehaviour
{
    public static int EnemiesAlives = 0;


    public LevelData data;
    public Wave[] waves; //Number of waves in the game

    public GameObject StartPoint, endPoint;
    [SerializeField] private float timeBetweenWaves = 5f;

    //Time of each wave and time Count down - Decrease in update to count time for spawning next wave
    private float timeCountDown = 2f;
    private int waveIndex = 0; //Currently Waves in the game


    Text waveCountDownText;
    static int enemiesToKill;

    private void Start()
    {
        StartPoint = GameObject.FindGameObjectWithTag("Start Point");
        data = gameObject.GetComponent<LevelData>();
    }
    private void Update()
    {
        CountDown();
    }

    public void CountDown()
    {
        if (waveIndex == waves.Length + 1)
        {
            Debug.Log("You Won");
            data.Win();
            enabled = false;
            return;
        }

        if (enemiesToKill > 0)
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
        //Cut off decimal, leave the first one number, always round, thx Felix
        GameManager.gm.textTime.text = string.Format("{0:00.00}", timeCountDown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.WavesCount++;
        Wave wave = waves[waveIndex++];
        enemiesToKill = wave.Count;

        for (int i = 0; i < wave.Count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.Rate);
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject nAnt = (GameObject)Instantiate(enemy, StartPoint.transform.position, Quaternion.identity);
        nAnt.GetComponent<EnemyMoving>().EndPoint = endPoint.transform;
        EnemiesAlives++;
    }

    internal static void OnEnemyDeath()
    {
        EnemySpawn.EnemiesAlives--;
        enemiesToKill--;
    }
}
