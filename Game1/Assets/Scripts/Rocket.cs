using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float timeToLive = 3f;
    public float damage = 30;
    public GameObject explosion;

    void Start()
    {
        StartCoroutine("selfDestruct");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gmobj = collision.gameObject;

        if (gmobj.layer != 12)
        {
            if (gmobj.layer == 8) // 8 = Enemies
            {
                gmobj.GetComponent<Enemy>().takeDamage(damage);
            }
            
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(timeToLive);
        Explode();
    } 
}
