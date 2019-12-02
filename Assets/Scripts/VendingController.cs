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
    

    public void Awake()
    {
        vm.SetActive(false);
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

    public void Show()
    {
        vm.SetActive(true);
    }

    public void Hide()
    {
        vm.SetActive(false);
    }
}


