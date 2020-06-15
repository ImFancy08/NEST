using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMoving : MonoBehaviour
{
    public Transform EndPoint;
    public NavMeshAgent enemyMeshAgent;

    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        enemyMeshAgent = this.GetComponent<NavMeshAgent>();
        enemyMeshAgent.updateRotation = false;
        if (EndPoint != null)
        {
            SetDestinationPoint();
        }
        else
        {
            Debug.Log("Attach the destination point to the enemy please");
        }

        if (enemy != null)
        {
            enemy.OnDeath += OnDeath;
        }
    }

    private void OnDeath()
    {
        enemyMeshAgent.enabled = false;
    }

    private void SetDestinationPoint()
    {
        if (EndPoint != null)
        {
            Vector3 target = EndPoint.transform.position;
            enemyMeshAgent.SetDestination(target);
        }
    }

    private void LateUpdate()
    {
        if (enemyMeshAgent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(enemyMeshAgent.velocity.normalized);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == EndPoint)
        {
            other.GetComponent<Enemy>().Die();
            Debug.Log("Touch");
        }
    }
}
