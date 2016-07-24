using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[Range (0f, 500f)]
	public float health;

	public void ReceiveDamage(float damage) {
		health -= damage;
	}

	public bool isAlive ()
	{
		return health > 0f;
	}

	public void Die() {
		Destroy(gameObject);
	}

	void Update ()
	{
		if (!isAlive ()) {
			Die ();
		}
	}
}
