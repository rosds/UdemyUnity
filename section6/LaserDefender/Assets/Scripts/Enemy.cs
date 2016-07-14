using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float health = 100f;
	public GameObject deadSound;
	public GameObject laser;

	void checkHealth ()
	{
		if (health <= 0f) {
			Instantiate(deadSound, transform.position, Quaternion.identity);
			Score score = FindObjectOfType<Score> ();
			if (score) {
				score.scorePoints(100);
			}
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Projectile laser = col.gameObject.GetComponent<Projectile>();
		if (laser) {
			health -= laser.getDamage();
			laser.hit();
			checkHealth();
		}
	}

	void enemyFire() {
		GameObject new_laser = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
		GetComponent<AudioSource>().Play();
	}

	void Start() {
		InvokeRepeating("enemyFire", Random.Range(0f, 1f), Time.deltaTime * 40f);
	}
}
