using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseScreen : MonoBehaviour
{
    public void Pause() 
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void Resume() 
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
