using System;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Unity Settings")]
    public Animator anim;
    NavMeshAgent enemy;
    public Action OnDeath;
    public Image healthBar;
    
    [Header("Attributes")]
    public float startHealth;
    private float health;

    public float speed;

    public int moneyGame = 50;



    public bool IsAlive => health > 0;

    private void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        enemy.speed = enemy.acceleration = speed;
    }

    void Start()
    {
        health = startHealth;
        anim = gameObject.GetComponent<Animator>();
        isDeathAnim(false);
    }

    public void takeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health/startHealth; 

        if(health <= 0)
        {
            Die();
            moneyGame = 0;
        }

    }
    
    public void Die()
    {
        health = 0;
        PlayerStats.Money += moneyGame;
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