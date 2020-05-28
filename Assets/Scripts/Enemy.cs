﻿using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    NavMeshAgent enemy;
    public int health;
    public float speed;
    public Action OnDeath;

    public bool IsAlive => health > 0;

    private void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        speed = enemy.speed = enemy.acceleration;
    }

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        isDeathAnim(false);
    }

    public void takeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }

    }
    
    public void Die()
    {
        speed = 0;
        isDeathAnim(true);
        EnemySpawn.OnEnemyDeath();
        OnDeath?.Invoke();
        Destroy(gameObject, 0.7f);
    }

    public void isDeathAnim(bool isDeath)
    {
        anim.SetBool("isDeath", isDeath);
    }
}