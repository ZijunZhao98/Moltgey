using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VendingController : MonoBehaviour
{
    // Start is called before the first frame update
    int count = 5;
    public Text cokeNum;
    public GameObject vm;
    int bb;
    public bool inRange;


    public void Awake()
    {
        vm.SetActive(false);
        //inRange = false;
    }

    public void BuyCoke()
    {
        bb = FindObjectOfType<PlayerController>().bearbucks;

        if (count > 0 && bb >= 10)
        {
            count--;
            cokeNum.text = count.ToString();
            FindObjectOfType<PlayerController>().cokeCount++;
            FindObjectOfType<PlayerController>().bearbucks -= 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (inRange)
            {
                Show();
            }
 
        }
    }

    public void Show()
    {
        FindObjectOfType<PlayerController>().isPaused = true;
        vm.SetActive(true);
    }

    public void Hide()
    {
        FindObjectOfType<PlayerController>().isPaused = false;
        vm.SetActive(false);
    }
}


