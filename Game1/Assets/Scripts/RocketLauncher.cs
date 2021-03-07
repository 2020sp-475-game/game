using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    public float damage = 30;
    public string rocket_launcher = "rocket launcher";

    public override string getWeaponName ()
    {
        return rocket_launcher;
    }

    public override void _Fire()
    {
        Transform spawn_loc = bulletSpawnLocation.transform;
        GameObject bullet = (GameObject) Instantiate(base.bullet, spawn_loc.position, spawn_loc.rotation);
        bullet.GetComponent<Rocket>().damage = damage;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = spawn_loc.up * base.bulletVelocity;
    }
}
