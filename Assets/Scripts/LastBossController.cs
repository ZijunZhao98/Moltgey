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

    // State Tracking
    public float timeElapesed;
    public float firngDelay = 2f;
    public float health = 300f;
    private Transform target;
    private float speed = 0.05f;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        target = spawnPoints[0];

        StartCoroutine("FiringTimer");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapesed += Time.deltaTime;

        if (health <= 150f)
        {
            speed = 0.1f;
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
        yield return new WaitForSeconds(firngDelay);
        fireProjectile();
        StartCoroutine("FiringTimer");

    }

    void fireProjectile()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
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
        Destroy(gameObject);
        //TODO: add bear bucks to player
    }


}
