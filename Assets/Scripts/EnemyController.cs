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
        
        if (scene.name == "First_floor")
        {
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
        }
        
        
    }
}
