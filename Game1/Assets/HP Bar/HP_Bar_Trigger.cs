using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Bar_Trigger : MonoBehaviour
{
    public GameObject Player;
    public Sprite HP_Bar;
    public Sprite Alt_HP_Bar;
    public GameObject Border;
    public GameObject Fill;
    private bool alt = false;

    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        GameObject colObject = collision.gameObject;

        if (GameObject.ReferenceEquals (Player, colObject))
        {
            print ("detecting player");
            if (alt == false)
            {
                Border.GetComponent<Image>().sprite = Alt_HP_Bar;
                Fill.GetComponent<Image>().color = new Color32 (205, 135, 140, 255);
                alt = true;
            } else 
            {
                Border.GetComponent<Image>().sprite = HP_Bar;
                Fill.GetComponent<Image>().color = new Color32 (192, 153, 240, 255);
                alt = false;
            }
        }
    }
}
