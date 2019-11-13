using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyController : MonoBehaviour
{
    Scene scene;
    public Transform character;
    float speed;

    public float maxSpeed;

    public float followDistance;

    public float stopDistance;

    public float slowingDistance;
    float dis;

    public GameObject projectilePrefab;
    private int sn = 4;

    private float time = 0.0f;
    private float interval = 1.0f;

    Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        originalPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.name == "Second_floor")
        {
            character = GameObject.FindWithTag("Player").transform;
            
            dis = Vector2.Distance(transform.position, character.position);
            if (dis > slowingDistance)
            {
                speed = maxSpeed;
            }
            else
            {
                speed = (dis / slowingDistance) * maxSpeed;
            }
            if (dis > followDistance )
            {
                transform.position = Vector2.MoveTowards(transform.position, character.position, speed * Time.deltaTime);
            }
            /*else if(Vector2.Distance(transform.position,character.position)>stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, originalPos, speed * Time.deltaTime);
            }*/
            else
            {
            
            }

            if ( Mathf.Abs(transform.position.x - character.position.x) >Mathf.Abs(transform.position.y - character.position.y))
            {
                if (transform.position.x > character.position.x)
                {
                    sn = 4;
                }
                else
                {
                    sn = 3;
                }
            }
            else
            {
                if (transform.position.y > character.position.y)
                {
                    sn = 2;
                }
                else
                {
                    sn = 1;
                }
            }


            time += Time.deltaTime;
            if (time >= interval)
            {
                Shoot();
                time = 0.0f;
            }
        }
        
        
    }
    
    
    
    
    private void Shoot()
    {
        GameObject newProjectile = Instantiate(projectilePrefab);
        newProjectile.transform.position = new Vector3(transform.position.x, transform.position.y, -1);

        switch (sn)
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
