using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int health;
    public float moveSpeed = 4f;
    public HealthBar healthBar;
    [HideInInspector]
    public GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        manageFlip();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
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
