using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SBMenuController : MonoBehaviour
{
    private void Awake()
    {
        Hide();
    }

    public void GoBack()
    {
        Hide();
        if(SceneManager.GetActiveScene().name == "spawnboss")
        {
            FindObjectOfType<PlayerController>().FinishSpawn = true;

        }else if(SceneManager.GetActiveScene().name == "LastBoss")
        {
            FindObjectOfType<PlayerController>().FinishLast = true;
        }
        SceneManager.LoadScene("First_floor");
        FindObjectOfType<PlayerController>().setPause();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
