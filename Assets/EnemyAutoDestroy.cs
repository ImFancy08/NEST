using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAutoDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Red Ant")
        {
            Debug.Log("Touch");
            Destroy(other.gameObject);
        }
    }
}
