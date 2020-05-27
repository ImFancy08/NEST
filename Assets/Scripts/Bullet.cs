using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform targetenemy;

    public float speed = 10f;
    public int damage = 1;

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
        transform.LookAt(targetenemy);
    }

    private void hitTheTarget()
    {
        Damage(targetenemy);
    }

    private void Damage(Transform targetenemy)
    {
        Enemy enemy = targetenemy.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
