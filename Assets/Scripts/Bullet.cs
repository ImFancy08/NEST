using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform targetenemy;

    [SerializeField] float speed = 50f;

    public void Chase(Transform target)
    {
        targetenemy = target; 
    }

    // Update is called once per frame
    void Update()
    {
        if(targetenemy == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = targetenemy.position - transform.position;
        float distance = speed * Time.deltaTime;

        if(dir.magnitude <= distance)
        {
            hitTheTarget();
            return;
        }

        transform.Translate(dir.normalized * distance, Space.World);
    }

    private void hitTheTarget()
    {
        targetenemy.GetComponent<Enemy>().Die();
        Destroy(gameObject);
    }
}
