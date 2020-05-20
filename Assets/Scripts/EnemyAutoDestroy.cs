using UnityEngine;

public class EnemyAutoDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" )
        {

            Debug.Log("Touch");
            other.GetComponent<Enemy>().Die();
        }
    }

}
