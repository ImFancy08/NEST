using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField]
    public Transform EndPoint;
    NavMeshAgent EnemyMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        EnemyMeshAgent = this.GetComponent<NavMeshAgent>();
        EnemyMeshAgent.updateRotation = false;
        if (EndPoint != null)
        {
            SetDestinationPoint();
        }
        else
        {
            Debug.Log("Attach the destination point to the enemy please");
        }
    }

    private void SetDestinationPoint()
    {
        if (EndPoint != null)
        {
            Vector3 target = EndPoint.transform.position;
            EnemyMeshAgent.SetDestination(target);
        }
    }

    private void LateUpdate()
    {
        if (EnemyMeshAgent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            transform.rotation = Quaternion.LookRotation(EnemyMeshAgent.velocity.normalized);
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
