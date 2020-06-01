using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform targetenemy;
    public float explosionRadius = 0f;

    public float speed = 10f;
    public int damage = 1;

    public GameObject impactEffect;
    public GameObject fire;
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
            GameObject effectInstance = (GameObject)Instantiate(fire, transform.position, transform.rotation);
            hitTheTarget();
            Destroy(effectInstance, 2f);
            return;
        }

        transform.Translate(dir.normalized * distance, Space.World);
        transform.LookAt(targetenemy);
    }

    private void hitTheTarget()
    {
        GameObject effectInstace = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstace, 5f);
        if(explosionRadius >= 0f)
        {
            Explode();
        }
        else
        {
            Damage(targetenemy);
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
