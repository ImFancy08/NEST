using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField]
    Transform EndPoint;
    NavMeshAgent EnemyMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        EnemyMeshAgent = this.GetComponent<NavMeshAgent>();
        if(EndPoint == null)
        {
            Debug.Log("Attach the destination point to the enemy please");
        }
        else
        {
            SetDestinationPoint();
        }
    }

    private void SetDestinationPoint()
    {
        if(EndPoint != null)
        {
            Vector3 target = EndPoint.transform.position;
            EnemyMeshAgent.SetDestination(target);
        }
    }
}
