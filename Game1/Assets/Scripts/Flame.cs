using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float timeToLive = 6f;
    public int damagePerSecond = 6;
    private bool canDamage = true;

    void Start()
    {
        StartCoroutine("selfDestruct");
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject gmobj = collision.gameObject;

        if (gmobj.layer != 12)
        {
            if (gmobj.layer == 8 && canDamage) // 8 = Enemies
            {
                gmobj.GetComponent<Enemy>().takeDamage(damagePerSecond);
                StartCoroutine("doDamage");
            }
        }
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    } 

    IEnumerator doDamage()
    {
        canDamage = false;
        yield return new WaitForSeconds(.5f);
        canDamage = true;
    }
}
