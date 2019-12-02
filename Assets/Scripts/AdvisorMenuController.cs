using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvisorMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnMenu;
    public GameObject choiceMenu;

    private void Awake()
    {
        Hide();
    }

    public void chooseSpwanBosses()
    {
        choiceMenu.SetActive(false);
        spawnMenu.SetActive(true);
    }

    public void startSpawn()
    {
        SceneManager.LoadScene("spawnboss");
    }

    public void chooseLastBoss()
    {
        Hide();
        SceneManager.LoadScene("LastBoss");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
