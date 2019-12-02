using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LastBossController : MonoBehaviour
{
    // Outlets
    public Transform[] spawnPoints;
    public GameObject projectilePrefab;
    

    // Conponent
    Rigidbody2D rigidbody;
	public Animator animator;
	GameObject characterObj;
    public GameObject win;

    // State Tracking
    public float timeElapesed;
    public float firingDelay;
    public float health = 200f;
    private Transform target;
    private float speed;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        characterObj = GameObject.FindWithTag("Player");

        target = spawnPoints[0];
        firingDelay = 2f;
        speed = 0.08f;

        StartCoroutine("FiringTimer");
    }

    // Update is called once per frame
    void Update()
    {
        // time
        timeElapesed += Time.deltaTime;

        // Animator
        //float movementSpeed = speed;
        animator.SetFloat("speed", speed);
        if (speed > 0.05f)
        {
            animator.SetFloat("movementX", target.position.x - transform.position.x);
            animator.SetFloat("movementY", target.position.y - transform.position.y);
        }

        // Change Boss Attack Pattern
        if (health <= 10f)
        {
            speed = 0.1f;
            firingDelay = 1f;
        }

        // Moving towards random points
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
        if ((transform.position - target.position).magnitude < 0.1)
        {
            target = spawnPoints[Random.Range(0, spawnPoints.Length)];
        }

        
    }

    // 
    IEnumerator FiringTimer()
    {
        yield return new WaitForSeconds(firingDelay);
        fireProjectile();
        StartCoroutine("FiringTimer");

    }

    void fireProjectile()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(10);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        characterObj.GetComponent<PlayerController>().AddBB(100);
        Destroy(gameObject);
        Win();
        //TODO: add bear bucks to player
    }

    void Win()
    {
        FindObjectOfType<PlayerController>().isPaused = true;
        win.SetActive(true);

    }
}
