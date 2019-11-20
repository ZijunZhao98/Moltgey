using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Outlect
    Rigidbody2D rigidbody;

    // Methods
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (transform.rotation.y == 90 || transform.rotation.y == -90)
        {
            Debug.Log("I am here");
            rigidbody.velocity = transform.up * 15f;
        }
        else
        {
            rigidbody.velocity = transform.right * 15f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        // Gaining Damage
        PlayerController.instance.TakeDamage(10f);

    }


    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
