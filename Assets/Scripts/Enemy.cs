using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent enemy;
    [SerializeField]
    public float health, speed;

    private void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        enemy.speed = enemy.acceleration = speed;
    }

    public void Die()
    {
        EnemySpawn.OnEnemyDeath();
        Destroy(gameObject);
    }
}