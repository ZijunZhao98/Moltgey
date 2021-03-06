﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyController : MonoBehaviour
{
    Scene scene;
    public Transform character;
    GameObject characterObj;
    float speed;
    //public Animator animator;
    SpriteRenderer _spriteRenderer;

    public float maxSpeed;
    public float followDistance;
    public float stopDistance;
    public float slowingDistance;
    public float health = 50f;
    float dis;

    public GameObject projectilePrefab;

    private int sn = 4;
    private float time = 0.0f;
    private float interval = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        characterObj = GameObject.FindWithTag("Player");
        //animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("speed", maxSpeed);
        //if (maxSpeed > 0.05f)
        //{
        //    animator.SetFloat("movementX", character.position.x - transform.position.x);
        //    animator.SetFloat("movementY", character.position.y - transform.position.y);
        //}


        if (GameObject.FindWithTag("Player") != null)
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
            if (dis > followDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, character.position, speed * Time.deltaTime);
            }

            time += Time.deltaTime;
            if (time >= interval)
            {
                GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                
                
                time = 0.0f;
            }
        }

    }

    public void changeSprite()
    {
        _spriteRenderer.sprite = Resources.Load("aa_0", typeof(Sprite)) as Sprite;
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
        characterObj.GetComponent<PlayerController>().AddBB(10);
        Destroy(gameObject);
        FindObjectOfType<SpawnController>().killIncrement();

        //TODO: add bear bucks to player
    }
    
    
}
 