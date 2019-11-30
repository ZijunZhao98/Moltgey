using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainController : MonoBehaviour
{
    // Outlets
    public GameObject projectilePrefab;

    // Configuration
	Rigidbody2D _rigidbody;
//	public Image imageHealthBar;

    // State TRacking
	public float healthMax = 100f;
	public float health = 100f;
	public float moveSpeed;


	void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame

	void Update()
	{
		//time += Time.deltaTime;
		float movementSpeed = _rigidbody.velocity.magnitude;
		

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
		if (health <= 0)
		{
			Die();
		}

		//imageHealthBar.fillAmount = health / healthMax;
	}

	void Die()
	{
		Destroy(gameObject);
		SceneManager.LoadScene("GameEND");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			TakeDamage(10);
		}
	}


}
 