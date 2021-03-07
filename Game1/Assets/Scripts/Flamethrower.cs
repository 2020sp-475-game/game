using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Weapon
{
    public ParticleSystem flames;
    public float damage = 0.5f;
    public string flamethrower = "flamethrower";

    public override string getWeaponName ()
    {
        return flamethrower;
    }
    
    public void Awake ()
    {
        flames = GetComponent<ParticleSystem>();
        flames.Stop();
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
        if (other.layer != 12)
        {
            if (other.layer == 8) // 8 == Enemies
            {
                other.GetComponent<Enemy>().takeDamage(damage);
            }
        }
    }

    void onDestroy()
    {
        flames.Clear();
        flames.Stop();
    }
}
