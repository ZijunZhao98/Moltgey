using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : MonoBehaviour
{

    public Animator animator;
    Rigidbody2D rigidbody;
    public GameObject projectilePrefab;

    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.UpArrow))
        {
            AudioManager.instance.Play("Footsteps_on_Cement");
            transform.position += new Vector3(0, 0.2f, 0);

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            AudioManager.instance.Play("Footsteps_on_Cement");
            transform.position += new Vector3(0, -0.2f, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            AudioManager.instance.Play("Footsteps_on_Cement");
            transform.position += new Vector3(0.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            AudioManager.instance.Play("Footsteps_on_Cement");
            transform.position += new Vector3(-0.2f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject newProjectile = Instantiate(projectilePrefab);
            newProjectile.transform.position = transform.position;
            newProjectile.transform.rotation = transform.rotation;
        }

        //send values to animator
        animator.SetBool("WalkRight", Input.GetKey(KeyCode.RightArrow));
        animator.SetBool("WalkLeft", Input.GetKey(KeyCode.LeftArrow));
        animator.SetBool("WalkDown", Input.GetKey(KeyCode.DownArrow));
        animator.SetBool("WalkUp", Input.GetKey(KeyCode.UpArrow));
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));



    }


}
