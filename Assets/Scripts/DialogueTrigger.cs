using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool playerInRange;
    bool startD = false;

	public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
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
