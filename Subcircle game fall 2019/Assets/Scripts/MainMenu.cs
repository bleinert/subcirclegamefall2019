using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //There should be a next scene when building game
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit(); //Quit the application
    }
}
