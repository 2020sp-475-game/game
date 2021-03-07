using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    private ParticleSystem explosion_particles;

    void Awake()
    {
        explosion_particles = GetComponent<ParticleSystem>();
        float rad = GetComponent<CircleCollider2D>().radius;
        int layer_mask = LayerMask.GetMask("Enemy");

        RaycastHit2D[] enemiesInRad = Physics2D.CircleCastAll(gameObject.transform.position, rad, new Vector2 (1, 1), Mathf.Infinity, layer_mask, Mathf.Infinity, Mathf.Infinity);
        foreach(RaycastHit2D enemy in enemiesInRad)
        {
            enemy.collider.GetComponent<Enemy>().takeDamage(30);
        }

        StartCoroutine("selfDestruct");
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    } 
}
