using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class EnemySpawn : MonoBehaviour
{
    public static int EnemiesAlives = 0;


    public LevelData levelData;
    public Wave[] waves; //Number of waves in the game

    public GameObject StartPoint, endPoint;
    [SerializeField] private float timeBetweenWaves = 5f;

    //Time of each wave and time Count down - Decrease in update to count time for spawning next wave
    public static float timeCountDown;
    private int waveIndex = 0; //Currently Waves in the game


    Text waveCountDownText;

    private void Start()
    {
        timeCountDown = timeBetweenWaves;
        StartPoint = GameObject.FindGameObjectWithTag("Start Point");
        levelData = gameObject.GetComponent<LevelData>();
    }
    private void Update()
    {
        CountDown();
    }

    public void CountDown()
    {
        if (!GameManager.GameIsOver && PlayerStats.Lives > 0)
        {
            if (EnemiesAlives > 0)
            {
                return;
            }

            if (waveIndex == waves.Length)
            {
                levelData.Win();
                enabled = false;
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
            if (GameManager.gm != null)
            {
                GameManager.gm.textTime.text = string.Format("{0:00.00}", timeCountDown);
            }
            else
            {
                Debug.Log("Enable Main Menu");
                return;
            }
        }
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.WavesCount++;
        Wave wave = waves[waveIndex];
        EnemiesAlives = wave.Count;

        for (int i = 0; i < wave.Count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.Rate);
        }
        waveIndex++;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject nAnt = (GameObject)Instantiate(enemy, StartPoint.transform.position, Quaternion.identity);
        nAnt.GetComponent<EnemyMoving>().EndPoint = endPoint.transform;
        //EnemiesAlives++;
    }

    internal static void OnEnemyDeath()
    {
        EnemiesAlives--;
    }
}
