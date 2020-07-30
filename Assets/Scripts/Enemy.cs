using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Unity Settings")]
    public Animator anim;
    public Action OnDeath;
    public Image healthBar;
    public EnemyMoving enemyMoving;
    public AudioSource audioSource;

    [Header("Attributes")]
    public float startHealth;
    public float health;
    public float startSpeed;

    [Header("Sound Manager")]
    public AudioClip deathSound;

    [HideInInspector]
    public float speed = 0f;

    public int moneyGame = 50;

    public bool IsAlive => health > 0;

    void Start()
    {
        enemyMoving = GetComponent<EnemyMoving>();
        speed = startSpeed;
        health = startHealth;
        anim = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        isDeathAnim(false);
    }

    private void Update()
    {
        //cheating();
    }

    void cheating()
    {
        if(gameObject.tag == "Enemy" && health > 0 && Input.GetKeyDown("q"))
        {
            health = 0;
            Die();
        }
        else if(gameObject.tag == "FlyEnemy" && health > 0 && Input.GetKeyDown("q"))
        {
            health = 0;
            Die();
        }
        else { 
            return;
        }
    }
    public void takeDamage(float amount)
    {
        audioSource.Play();
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
        audioSource.clip = deathSound;
        audioSource.Play();
        health = 0;
        PlayerStats.Money += moneyGame;
        isDeathAnim(true);
        EnemySpawn.OnEnemyDeath();
        OnDeath?.Invoke();
        Destroy(gameObject, 1f);
    }

    public void isDeathAnim(bool isDeath)
    {
        anim.SetBool("isDeath", isDeath);
    }

    public void Slow(float slowPercentage)
    {
        speed = startSpeed*(1f - slowPercentage);
        StartCoroutine(ChangeSpeedBack());
    }

    IEnumerator ChangeSpeedBack()
    {
        yield return new WaitForSeconds(5);
        speed = startSpeed;
    }
}