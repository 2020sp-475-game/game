using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool bouncy = false;
    public float timeToLive = 6f;
    public int damage = 6;

    void Start()
    {
        StartCoroutine("selfDestruct");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gmobj = collision.gameObject;
        
        if (!bouncy && gmobj.layer != 12)
        {
            if (gmobj.layer == 8) // 8 = Enemies
            {
                gmobj.GetComponent<Enemy>().takeDamage(damage);
            }
            
            Destroy(gameObject);
        }
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    } 
}
