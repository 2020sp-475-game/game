using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawnLocation;

    public float shotsPerSecond = 2f;
    public float bulletVelocity = 50f;
    public int magCapacity = 12;
    public float accuracy = 20f;
    [HideInInspector]
    public int roundsInMag = 12;

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
    }

    void Update()
    {
        roundsInMag = magCapacity - shots_fired;
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
        yield return new WaitForSeconds(2.5f);
        shots_fired = 0;
        reloading = false;
    }
}
