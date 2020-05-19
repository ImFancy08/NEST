using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            EnemySpawn.EnemiesAlives--;
        }
    }
}
