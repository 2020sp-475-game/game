using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{ 
    // Public Primitives
    public Text ammoCount;
    public float moveSpeed = 4f;
    public float maxHealth = 100;
    public float currentHealth;
    public bool isDead = false;
    public GameOverScreen GameOverScreen;
    public GamePauseScreen GamePauseScreen;

    // Public Game Objects
    [HideInInspector]
    public Rigidbody2D rb;
    public HealthBar healthBar;
    public GameObject currentWeapon;
    public GameObject[] weaponsList;

    // Privates
    private Camera cam;
    //private float lastSwap = 0;

    // Called in the beginning
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth (maxHealth);
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        swapToRandomWeapon();
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

        if (currentWeapon)
        {
            // Swap when ammo runs out
            if (currentWeapon.GetComponent<Weapon>().totalAmmo <= 0)
            {
                swapToRandomWeapon ();
            }

            if (Input.GetAxis("Fire1") > 0f)
            {
                if (currentWeapon.GetComponent<Weapon>())
                {
                    currentWeapon.GetComponent<Weapon>().Fire();
                } else {
                    print("No currentWeapon found");
                }
            }
        } else {
            swapToRandomWeapon();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Handles character always aiming towards mouse
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        if(Input.GetKey("escape") && isDead == false) 
        {   
            GamePauseScreen.Pause();
        }
    }

    void Death()
    {
        // Animation or something here
        GameOverScreen.Setup();
    }

    // Updates current health based on damage taken
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            isDead = true;
            currentHealth = 0;
            Death();
        }
        healthBar.SetHealth(currentHealth);
    }

    public void addHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    void swapToRandomWeapon ()
    {
        int idx = (int)Random.Range(0, weaponsList.Length);
        Destroy(currentWeapon);
        print(weaponsList[idx].transform.position);
        GameObject newWeapon = (GameObject) Instantiate(weaponsList[idx], transform);
        currentWeapon = newWeapon;
    }
}
