using System;
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
        enemy.speed = enemy.acceleration = speed;
    }

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        isDeathAnim(false);
        queenIsDeathAnim(false);
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
        isDeathAnim(true);
        queenIsDeathAnim(true);
        EnemySpawn.OnEnemyDeath();
        OnDeath?.Invoke();
        Destroy(gameObject, 0.7f);
    }

    private void queenIsDeathAnim(bool queenAntDeath)
    {
        anim.SetBool("queenAntDeath", queenAntDeath);
    }

    public void isDeathAnim(bool isDeath)
    {
        anim.SetBool("isDeath", isDeath);
    }
}