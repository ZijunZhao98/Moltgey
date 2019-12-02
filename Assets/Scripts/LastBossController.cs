using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LastBossController : MonoBehaviour
{

    // Outlets
    public Transform[] spawnPoints;

    //Scene scene;
    public Transform character;
    public GameObject projectilePrefab;
    Rigidbody2D rigidbody;

    // State Tracking
    public float timeElapesed;
    public float maxSpeed;
    public float followDistance;
    public float stopDistance;
    public float slowingDistance;
    float dis;
    float speed = 4;

    public float health = 50f;
    private int sn = 4;
    private float time = 0.0f;
    private float interval = 3.0f;

    private int currentP = 0;
    private Transform target;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        target = spawnPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        timeElapesed += Time.deltaTime;

        time += Time.deltaTime;

        if (time >= interval)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            time = 0.0f;
        }



        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if ((transform.position - target.position).magnitude < 0.3)
        {
            currentP++;
            if (currentP == spawnPoints.Length)
            {
                currentP = 0;
            }

            target = spawnPoints[currentP];
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
        Destroy(gameObject);
        //TODO: add bear bucks to player
    }


}
