using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : MonoBehaviour
{

    public Animator animator;
    Rigidbody2D rigidbody;
    private SpriteRenderer sprite;

    //private static bool created = false;

    ////code from documentation: https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-name.html
    //private void Awake()
    //{
    //    if (!created)
    //    {
    //        DontDestroyOnLoad(this.gameObject);
    //        created = true;
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }

    //}
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0.2f, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -0.2f, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.2f, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.2f, 0, 0);
        }*/
        animator.SetFloat(("Vertical"),Input.GetAxis("Vertical"));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal*Time.deltaTime;
        Vector3 vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
        transform.position = transform.position + vertical*Time.deltaTime;
        
        
        
    }
    

}
