using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawnLocation;

    public float shotsPerSecond = 2f;
    public float bulletVelocity = 50f;
    public int magCapacity = 12;
    public float accuracy = 20f;
    public string weaponName;
    [HideInInspector]
    public int roundsInMag = 12;
    public float reloadTime = 2.5f;
    public int totalAmmo;

    // private variables
    private Camera camera;
    private float last_shot = 0;
    private Vector3 moveDirection;
    private Vector3 mouse_pos;
    private int shots_fired = 0;
    private bool reloading = false;

    void Start()
    {
        camera = Camera.main;
        roundsInMag = magCapacity;
        totalAmmo = magCapacity * 4;
    }

    void Update()
    {
        roundsInMag = magCapacity - shots_fired;
    }

    public virtual string getWeaponName ()
    {
        return "This shouldn't run";
    }

    public void Fire()
    {
        if (Time.time - last_shot >= 1/shotsPerSecond)
        {
            if(shots_fired < magCapacity)
            {
                _Fire();
                last_shot = Time.time;
                shots_fired++;
                totalAmmo--;           
            } else {
                if (!reloading) 
                {
                    reloading = true;
                    StartCoroutine("Reload");
                }
            }
        }
    }

    public virtual void _Fire()
    {
        print("Fire() not implemented in Weapon subclass or Weapon not added");
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        shots_fired = 0;
        reloading = false;
    }
}
