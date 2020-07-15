using UnityEngine;

public class EnemyAutoDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "FlyEnemy")
        {

            Debug.Log("Touch");
            other.GetComponent<Enemy>().Die();
            PlayerStats.Lives--;
        }
    }

}
