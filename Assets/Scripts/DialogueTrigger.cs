using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool playerInRange;
    bool startD = false;
    public GameObject temp;
    public bool first;

	public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<PlayerController>().isPaused = true;
        
    }

    public void NextSentence()
    {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (playerInRange && startD == false)
            {
                if (SceneManager.GetActiveScene().name == "First_floor")
                {
                    temp.SetActive(false);
                }
                TriggerDialogue();
                
                startD = true;
            }else if(playerInRange && startD == true)
            {
    
                NextSentence();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            first = FindObjectOfType<PlayerController>().firstPlay;
            if (SceneManager.GetActiveScene().name == "First_floor" && first == true)
            {
                temp.SetActive(true);
                FindObjectOfType<PlayerController>().firstPlay = false;
            }
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            playerInRange = false;
            startD = false;
        }
    }
}
