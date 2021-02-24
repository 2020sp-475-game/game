using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{ 
    // Public Primitives
    public Text ammoCount;
    public float moveSpeed = 4f;
    public int maxHealth = 100;
    public int currentHealth;

    // Public Game Objects
    [HideInInspector]
    public Rigidbody2D rb;
    public HealthBar healthBar;
    public GameObject weapon;

    // Privates
    private Camera cam;

    // Called in the beginning
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth (maxHealth);
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    Vector2 movement;   
    Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Sets camera to track and stay on character
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Health Bar updates
        if (Input.GetKeyDown(KeyCode.Space)) /*THIS WILL CHANGE LATER TO THE ENEMY HITTING THE PLAYER*/
        {
            TakeDamage(20);  /*THIS WILL ALSO CHANGE AS WELL TO THE ENEMY DAMAGE BEING DONE*/
        }

        if (weapon)
        {
            if (Input.GetAxis("Fire1") > 0f)
            {
                if (weapon.GetComponent<Weapon>())
                {
                    weapon.GetComponent<Weapon>().Fire();
                } else {
                    print("No weapon found");
                }
            }

            //ammoCount.text = "Ammo: " + weapon.GetComponent<Weapon>().roundsInMag;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Handles character always aiming towards mouse
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    // Updates current health based on damage taken
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
