using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Assets/Scenes/Game.unity");
    }

    public void Restart(){
        SceneManager.LoadScene("Assets/Scenes/Menu.unity");
        SceneManager.LoadScene("Assets/Scenes/Game.unity");
    }

    public void Options()
    {
        SceneManager.LoadScene("Assets/Scenes/Options.unity");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Assets/Scenes/Menu.unity");
    }

    public void QuitGame() 
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
