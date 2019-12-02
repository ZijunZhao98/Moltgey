using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Code resources from: forum.brackeys.com
    public void PlayGame()
    {
        // load the next scene in the queue
        // Scene index 0: GameStart
        //             1: First_Floor
        SceneManager.LoadScene("First_floor");
    }

    public void QuitGame()
    {
        //Debug.Log("QUIT"); // console display "QUIT"
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
