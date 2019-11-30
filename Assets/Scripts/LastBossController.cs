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
    float speed;

    public float health = 50f;
    private int sn = 4;
    private float time = 0.0f;
    private float interval = 3.0f;

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

            time += Time.deltaTime;

            if (time >= interval)
            {
                GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                
                
                time = 0.0f;
            }

            

            if (transform.position.x == 10 && transform.position.y == 0)
            {
                //log
                Debug.Log("sjakhdslkjh");
                transform.position = Vector2.MoveTowards(transform.position, spawnPoints[2].position, speed * Time.deltaTime);
                //Wait(10);
            } else if (transform.position.x == 0 && transform.position.y == 6)
            {
                transform.position = Vector2.MoveTowards(transform.position, spawnPoints[3].position, speed * Time.deltaTime);
            }else if (transform.position.x == -10 && transform.position.y == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, spawnPoints[1].position, speed * Time.deltaTime);
            }else if (transform.position.x == 0 && transform.position.y == -6)
            {
                transform.position = Vector2.MoveTowards(transform.position, spawnPoints[0].position, speed * Time.deltaTime);
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
 