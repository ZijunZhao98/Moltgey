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
        SceneManager.LoadScene("First_floor");
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
