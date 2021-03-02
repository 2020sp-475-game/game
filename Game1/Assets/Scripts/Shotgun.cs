using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public int pelletCount = 5;
    
    public override void _Fire()
    {
        Transform spawn_loc = bulletSpawnLocation.transform;
        for (int i=0; i<pelletCount; i++)
        {
            GameObject bullet = (GameObject) Instantiate(base.bullet, spawn_loc.position, spawn_loc.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Transform trans = bullet.GetComponent<Transform>();

            float inaccuracy = Random.Range(-base.accuracy, base.accuracy);
            trans.Rotate(new Vector3(0, 0, inaccuracy));
            rb.velocity = trans.up * base.bulletVelocity;
        }
    }
}
