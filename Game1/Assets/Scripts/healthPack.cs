using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPack : MonoBehaviour
{
    public float healAmount = 25f;
    public int respawnTime = 10;
    private GameObject Player;
    
    private void OnTriggerEnter2D (Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")  
        {
            other.gameObject.GetComponent<playerController>().addHealth(healAmount);
            StartCoroutine("reset");
        }  
    }

    IEnumerator reset()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(respawnTime);
        
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        
    } 
}
