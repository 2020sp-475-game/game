using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{
    public ParticleSystem flames;

    public void Start ()
    {
        flames = GetComponent<ParticleSystem>();
        flames.Pause();
    }

    public override void _Fire()
    {
        StartCoroutine("unPause");
    }

    IEnumerator unPause()
    {
        flames.Emit(5);
        flames.Play();
        yield return new WaitForSeconds(1);
    } 

    void OnParticleCollision(GameObject other)
    {
        //print("collision");
        if (other.layer != 12)
        {
            if (other.layer == 8) // 8 == Enemies
            {
                other.GetComponent<Enemy>().takeDamage(1);
            }
        }
    }
}
