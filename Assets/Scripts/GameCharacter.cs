using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCharacter : MonoBehaviour
{

    public static GameCharacter instance;
    // Outlets
    public Animator animator;
    Rigidbody2D rigidbody;
    private SpriteRenderer sprite;

    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);



        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("Background Music");
        print("play music.");
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //AudioManager.instance.Play("Footsteps_on_Cement");
            transform.position += new Vector3(0, 0.2f, 0);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //AudioManager.instance.Play("Footsteps_on_Cement");
            transform.position += new Vector3(0, -0.2f, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //AudioManager.instance.Play("Footsteps_on_Cement");
            transform.position += new Vector3(0.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //AudioManager.instance.Play("Footsteps_on_Cement");
            transform.position += new Vector3(-0.2f, 0, 0);
        }

        //send values to animator
        animator.SetBool("WalkRight", Input.GetKey(KeyCode.RightArrow));
        animator.SetBool("WalkLeft", Input.GetKey(KeyCode.LeftArrow));
        animator.SetBool("WalkDown", Input.GetKey(KeyCode.DownArrow));
        animator.SetBool("WalkUp", Input.GetKey(KeyCode.UpArrow));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("RunDown"));
        
        


        //Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        //transform.position = transform.position + horizontal*Time.deltaTime;
        //Vector3 vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
        //transform.position = transform.position + vertical*Time.deltaTime;



    }
}
