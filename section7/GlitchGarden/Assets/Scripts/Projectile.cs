using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	[Range (0f, 30f)]
	public float speed;

	[Range (0f, 50f)]
	public float damage;

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);	
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		GameObject obj = collider.gameObject;
		if (obj.GetComponent<Attacker> ()) {
			Health health = obj.GetComponent<Health> ();
			if (health) {
				health.ReceiveDamage(damage);
				Destroy(gameObject);
			}
		}
	}
}
