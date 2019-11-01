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
    public GameObject projectilePrefab;

    private SpriteRenderer sprite;
    private int switchNum = 3;

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
            switchNum = 1;
            transform.position += new Vector3(0, 0.2f, 0);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //AudioManager.instance.Play("Footsteps_on_Cement");
            switchNum = 2;
            transform.position += new Vector3(0, -0.2f, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //AudioManager.instance.Play("Footsteps_on_Cement");
            switchNum = 3;
            transform.position += new Vector3(0.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //AudioManager.instance.Play("Footsteps_on_Cement");
            switchNum = 4;
            transform.position += new Vector3(-0.2f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }

        //send values to animator
        animator.SetBool("WalkRight", Input.GetKey(KeyCode.RightArrow));
        animator.SetBool("WalkLeft", Input.GetKey(KeyCode.LeftArrow));
        animator.SetBool("WalkDown", Input.GetKey(KeyCode.DownArrow));
        animator.SetBool("WalkUp", Input.GetKey(KeyCode.UpArrow));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));

    }

    private void Shoot()
    {
        GameObject newProjectile = Instantiate(projectilePrefab);
        newProjectile.transform.position = new Vector3(transform.position.x, transform.position.y, -1);

        switch (switchNum)
        {
            case 1:
                newProjectile.transform.Rotate(0, 0, 90);
                break;
            case 2:
                newProjectile.transform.Rotate(0, 0, -90);
                break;
            case 3:
                newProjectile.transform.Rotate(0, 0, 0);
                break;
            case 4:
                newProjectile.transform.Rotate(0, 180, 0);
                break;
        }

    }
}
