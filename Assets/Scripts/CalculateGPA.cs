using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CalculateGPA : MonoBehaviour
{
    // Start is called before the first frame update
    public Text damage;
    public Text coke;
    public Text gpa;

    public float d;
    public int c;
    public float g;

    public void Start()
    {
        d = FindObjectOfType<PlayerController>().totalDemageReceived;
        damage.text = d.ToString();
        c = FindObjectOfType<PlayerController>().totalCokeUsed;
        coke.text =c.ToString();
        gpa.text = (4.0 - c * 0.2 - d / 100).ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("First_floor");
    }
}
