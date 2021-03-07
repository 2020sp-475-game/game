using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public float moveSpeed = 4f;
    public double distToPlayer = .8;
    public float damage = 3;
    public float attackPerSeconds = 2;
    public HealthBar healthBar;
    [HideInInspector]
    public GameObject Player;
    public GameObject GameManager;

    private bool canAttack = true;
    private AIPath aiScript;
    private AIDestinationSetter destSetter;

    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        GameManager = GameObject.FindGameObjectsWithTag("GameManager")[0];
       
        aiScript = GetComponent<AIPath>();
        aiScript.maxSpeed = moveSpeed;
        destSetter = GetComponent<AIDestinationSetter>();
        destSetter.target = Player.transform;

        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        healthBar.SetHealth(health);
        manageFlip();
        if (health <= 0)
        {
            GameManager.GetComponent<GameManager>().enemiesAlive -= 1;
            GameManager.GetComponent<GameManager>().score++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (canAttack && GameObject.ReferenceEquals (Player, other.gameObject))  
        {
            StartCoroutine("damagePlayer");
        }     
    }

    public IEnumerator damagePlayer ()
    {
        canAttack = false;
        Player.GetComponent<playerController>().TakeDamage(damage);
        yield return new WaitForSeconds(1/attackPerSeconds);
        canAttack = true;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }

    public virtual void Move()
    {
        print("Move() not implemented in subclass");
    }

    private void manageFlip()
    {
        Transform player_loc = Player.transform;
        Vector3 vector_to_target = player_loc.position - transform.position;
        float x_dir = Vector3.Normalize(vector_to_target).x;

        if (x_dir > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } 
        else if (x_dir < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
