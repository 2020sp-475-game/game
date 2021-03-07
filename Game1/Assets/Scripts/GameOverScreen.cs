using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public bool activeInfo = false;

    public void Setup()
    {
        activeInfo = true;
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        activeInfo  = false;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
