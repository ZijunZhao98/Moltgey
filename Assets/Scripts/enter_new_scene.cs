using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enter_new_scene: MonoBehaviour
{
    [SerializeField] private string newScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            SceneManager.LoadScene(newScene);

            collision.gameObject.transform.position = new Vector3(0, 0, 0);

        }
    }
}
