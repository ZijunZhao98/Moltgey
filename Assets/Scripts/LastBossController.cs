using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LastBossController : MonoBehaviour
{

    // Outlets
    public Transform[] spawnPoints;
    public Transform character;
    public GameObject projectilePrefab;
    Rigidbody2D rigidbody;

    // State Tracking
    public float timeElapesed;

    public float health = 50f;
    private int sn = 4;
    private float time = 0.0f;
    private float interval = 3.0f;
    Vector2 moveDirection;

    //void Awake()
    //{
    //    instance = this;
    //}
    // Start is called before the first frame update
    void Start()
    {
        //scene = SceneManager.GetActiveScene();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapesed += Time.deltaTime;
        character = GameObject.FindWithTag("Player").transform;

        if(character != null)
        {
            //dis = Vector2.Distance(transform.position, character.position);
            float movementSpeed = rigidbody.velocity.magnitude;

            time += Time.deltaTime;

            if (time >= interval)
            {
                GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                
                
                time = 0.0f;
            }

            

            if (transform.position.x == spawnPoints[0].position.x && transform.position.y == spawnPoints[0].position.y)
            {
                //log
                Debug.Log("sjakhdslkjh");
                //transform.position = Vector2.MoveTowards(transform.position, spawnPoints[2].position, speed * Time.deltaTime);
                //transform.position = spawnPoints[2].position;
                //transform.position = Vector2.MoveTowards(transform.position, spawnPoints[2].position, 5f);
                moveDirection = (spawnPoints[2].position - transform.position).normalized * 3f;
                rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);


            } else if (transform.position.x == spawnPoints[2].position.x && transform.position.y == spawnPoints[2].position.y)
            {
                //transform.position = Vector2.MoveTowards(transform.position, spawnPoints[3].position, speed * Time.deltaTime);
                //transform.position = Vector2.MoveTowards(transform.position, spawnPoints[3].position, 2f);
                moveDirection = (spawnPoints[3].position - transform.position).normalized * 3f;
                rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);

            }
            else if (transform.position.x == spawnPoints[3].position.x && transform.position.y == spawnPoints[3].position.y)
            {
                //transform.position = Vector2.MoveTowards(transform.position, spawnPoints[1].position, speed * Time.deltaTime);
                moveDirection = (spawnPoints[1].position - transform.position).normalized * 3f;
                rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);

            } else if (transform.position.x == spawnPoints[1].position.x && transform.position.y == spawnPoints[1].position.y)
            {
                //transform.position = Vector2.MoveTowards(transform.position, spawnPoints[0].position, speed * Time.deltaTime);
                moveDirection = (spawnPoints[0].position - transform.position).normalized * 3f;
                rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);
            }

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
 