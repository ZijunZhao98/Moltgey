using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enter_2nd_floor : MonoBehaviour
{
    [SerializeField] private string newScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(newScene);
            //DontDestroyOnLoad(collision.gameObject);
            //SceneManager.LoadScene(1, LoadSceneMode.Additive);

            //SceneManager.MoveGameObjectToScene(collision.gameObject, SceneManager.GetSceneByBuildIndex(1));

            //Debug.Log("the current scene is: " + SceneManager.GetActiveScene().name);

        }
    }
}
