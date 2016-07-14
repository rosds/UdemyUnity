using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour
{
	public float speed = 15.0f;
	public GameObject projectile;
	public GameObject loseSound;
	public float projectileSpeed = 5f;
	public float fireRate = 0.2f;
	public float health = 500f;

	private Vector3 leftMost, rightMost;

	void Start() {
		float distance = transform.position.z - Camera.main.transform.position.z;
		leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
	}

	void Fire ()
	{
		GameObject new_projectile = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		new_projectile.GetComponent<Rigidbody2D>().velocity = Vector3.up * projectileSpeed;
	}

	void Update ()
	{

		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire", 0.00001f, fireRate);

			GetComponent<AudioSource>().Play();
		}

		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		float x_position = this.transform.position.x;
		x_position = Mathf.Clamp(x_position, leftMost.x, rightMost.x);

		Vector3 new_position = new Vector3(x_position, transform.position.y, 0);
		this.transform.position = new_position;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Projectile laser = col.gameObject.GetComponent<Projectile> ();
		if (laser) {
			health -= laser.getDamage ();
			laser.hit ();
			if (health <= 0f) {
				Instantiate(loseSound, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
		}
	}
}