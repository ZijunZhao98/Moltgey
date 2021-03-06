﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Direction
{
    Up = 0,
    Down = 1,
    Left = 2,
    Right = 3
}

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject projectilePrefab;

    //component
    public Animator _animator;
    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;
    public GameObject rootCanvas;
    public GameObject[] inventories;

    //UI
    public Image imageHealthBar;
    public Text bb;

    
    public float healthMax = 100f;
    public float health = 100f;
    public float moveSpeed;
    public bool Shootprojectile = true;
    public Direction facingDirection;
    public int bearbucks = 0;
    public int cokeCount = 0;

    public float totalDemageReceived = 0;
    public int totalCokeUsed = 0;
    public bool FinishSpawn = false;
    public bool FinishLast = false;
    public bool isPaused = false;
    public bool firstPlay;
    
    
    private void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] canvases = GameObject.FindGameObjectsWithTag("UI");

        if(canvases.Length > 1)
        {
            Destroy(rootCanvas);
        }
        else
        {
            DontDestroyOnLoad(rootCanvas);
        }

        if (players.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        isPaused = true;
        firstPlay = true;


    }

    // Update is called once per frame

    void Update()
    {
        UpdateCokeDisplay();
        if (isPaused)
        {
            //if (FinishSpawn || FinishLast)
            //{
            //    isPaused = false;
            //}
            //else
            //{
                return;
            //}
    }

        float movementSpeed = _rigidbody.velocity.magnitude;
        _animator.SetFloat("speed", movementSpeed);
        if (movementSpeed > 0.1f)
        {
            _animator.SetFloat("movementX", _rigidbody.velocity.x);
            _animator.SetFloat("movementY", _rigidbody.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int facingDirectionIndex = (int)facingDirection;
            Shoot(facingDirectionIndex);
        }

        if (Input.GetKeyDown(KeyCode.X) && cokeCount >= 0 && health < 100)
        {
            AddHealth();
        }
        if(SceneManager.GetActiveScene().name == "First_floor")
        {
            health = 100;
            imageHealthBar.fillAmount = health / healthMax;
        }
        

        if(FinishLast && FinishSpawn)
        {
            SceneManager.LoadScene("CalculateGPA");
            isPaused = true;
        }



        UpdateBB();
    }

    void FixedUpdate()
    {
        if (isPaused)
        {
            return;
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            _rigidbody.AddForce(Vector2.up * moveSpeed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _rigidbody.AddForce(Vector2.down * moveSpeed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rigidbody.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rigidbody.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
        }
    }

    private void LateUpdate()
    {
        if (string.Equals(_spriteRenderer.sprite.name, "rpgmaker_person_sprite_10"))
        {
            facingDirection = Direction.Up;
        }
        else if (string.Equals(_spriteRenderer.sprite.name, "rpgmaker_person_sprite_1"))
        {
            facingDirection = Direction.Down;
        }
        else if (string.Equals(_spriteRenderer.sprite.name, "rpgmaker_person_sprite_4"))
        {
            facingDirection = Direction.Left;
        }
        else if (string.Equals(_spriteRenderer.sprite.name, "rpgmaker_person_sprite_7"))
        {
            facingDirection = Direction.Right;
        }
    }

    public void setPause()
    {
        isPaused = true;
    }

    void Shoot(int d)
    {
        GameObject newProjectile = Instantiate(projectilePrefab);
        newProjectile.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        switch (d)
        {
            case 0:
                newProjectile.transform.Rotate(0, 0, 90);
                break;
            case 1:
                newProjectile.transform.Rotate(0, 0, -90);
                break;
            case 2:
                newProjectile.transform.Rotate(0, 180, 0);
                break;
            case 3:
                newProjectile.transform.Rotate(0, 0, 0);
                break;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        totalDemageReceived += damageAmount;
        if (health <= 0)
        {
            Die();
        }

        imageHealthBar.fillAmount = health / healthMax;
    }

    public void AddBB(int bb)
    {
        bearbucks += bb;
    }

    public void UpdateCokeDisplay()
    {
        for(int i = 0; i < 5; i++)
        {
            if(i < cokeCount)
            {
                inventories[i].SetActive(true);
            }
            else
            {
                inventories[i].SetActive(false);
            }
            
        }
    }

    public void UpdateBB()
    {
        bb.text = bearbucks.ToString();
    }

    public void Die()
    {
        justDestroy();
        SceneManager.LoadScene("GameEND");
    }

    public void justDestroy()
    {
        Destroy(this.gameObject);
        Destroy(rootCanvas);
    }

    void AddHealth()
    {
        health += 10;
        totalCokeUsed ++;
        cokeCount--;
        imageHealthBar.fillAmount = health / healthMax;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
        }
    }

}
