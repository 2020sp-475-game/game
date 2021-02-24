using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void _Fire()
    {
        Transform spawn_loc = bulletSpawnLocation.transform;
        GameObject bullet = (GameObject) Instantiate(base.bullet, spawn_loc.position, spawn_loc.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = spawn_loc.up * base.bulletVelocity;
    }
}
