using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public GameObject explosionPrefab;
    public float speed = 8f;
    GameObject character;
    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        character = GameObject.FindWithTag("Player");
        moveDirection = (character.transform.position - transform.position).normalized * speed;
        _rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y);


        Destroy(gameObject, 5f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(10);
        }
        if(collision.gameObject.tag != "EnemyProjectile")
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 0.25f);

    }
}
