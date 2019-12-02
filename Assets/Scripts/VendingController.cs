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

    public void Awake()
    {
        vm.SetActive(false);
    }

    public void BuyCoke()
    {
        if(count > 0)
        {
            count--;
            cokeNum.text = count.ToString();
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


