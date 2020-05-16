using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class EnemySpawn : MonoBehaviour
{
    [SerializeField] public static int EnemyAlives;

    [SerializeField] public GameObject normalAnt; //Basic Ant which is spawned
    [SerializeField] public GameObject StartPoint;
    [SerializeField] public GameObject endPoint;
    [SerializeField] public float timeBetweenWaves = 5f; //Time of each wave;
    [SerializeField] private float timeCountDown = 2f; //Time Count down - Decrease in update to count time for spawning next wave
    [SerializeField] private int waveIndex = 0;//Number of waves in the level

    [SerializeField] public Text waveCountDownText;

    private void Update()
    {
        if(timeCountDown <= 0)
        {
            StartCoroutine(SpawnWave());
            timeCountDown = timeBetweenWaves;
        }

        timeCountDown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Floor(timeCountDown).ToString();//Cut off decimal, leave the first one number, always round

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1.5f);
        }
    }

    private void SpawnEnemy()
    {
        GameObject nAnt = (GameObject) Instantiate(normalAnt, StartPoint.transform.position, Quaternion.identity);
        nAnt.GetComponent<EnemyMoving>().EndPoint = endPoint.transform;
    }
}
