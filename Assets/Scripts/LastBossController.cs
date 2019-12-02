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
    

    // Configuration
    Rigidbody2D rigidbody;
    GameObject characterObj;
    public GameObject win;

    // State Tracking
    public float timeElapesed;
    public float firingDelay;
    public float health = 200f;
    private Transform target;
    private float speed = 0.05f;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        characterObj = GameObject.FindWithTag("Player");

        target = spawnPoints[0];
        firingDelay = 2f;

        StartCoroutine("FiringTimer");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapesed += Time.deltaTime;

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
        win.SetActive(true);
    }
}
