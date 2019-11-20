using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Make Character an instance
    public static PlayerController instance;

    // Outlect
    Rigidbody2D rigidbody;
    public GameObject projectilePrefab;
    public Animator animator;
    public Image imageHealthBar;
    public GameObject rootCanvas;
    // Variables


    // State Tracking
    private int rotation = 3;
    public float healthMax = 100f;
    public float health = 100f;



    // Methods
    // Initialize the Character
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(rootCanvas);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            Destroy(rootCanvas);
            //DontDestroyOnLoad(rootCanvas);
        }
        //DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move Player Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation = 4;
            transform.position += new Vector3(-0.2f, 0, 0);
        }

        // Move Player right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation = 3;
            transform.position += new Vector3(0.2f, 0, 0);
        }

        // Move Player up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rotation = 1;
            transform.position += new Vector3(0, 0.2f, 0);
        }

        // Move Player down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rotation = 2;
            transform.position += new Vector3(0, -0.2f, 0);
        }

        // Shoot Projectile ONLY in certain Scene
        if (Input.GetKey(KeyCode.X) && SceneManager.GetActiveScene().buildIndex == 1)
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

    // Shoot projectile
    void Shoot()
    {
        GameObject newProjectile = Instantiate(projectilePrefab);
        newProjectile.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        switch (rotation)
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


    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }

        imageHealthBar.fillAmount = health / healthMax;
    }

    void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(4);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile>())
        {
            TakeDamage(10f);
        }
    }
}
