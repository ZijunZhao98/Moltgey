﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if(transform.rotation.y == 90 || transform.rotation.y == -90)
        {
            rigidbody.velocity = transform.up* 15f;
        }
        else
        {
            rigidbody.velocity = transform.right * 15f;
        }

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(15);
        }

        if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<LastBossController>().TakeDamage(15);
        }
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 0.25f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 0.25f);
    }

}
