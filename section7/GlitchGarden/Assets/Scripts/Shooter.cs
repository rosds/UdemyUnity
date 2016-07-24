using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	private GameObject parent;
	private Spawner mySpawner;
	private Animator animator;

	// Use this for initialization
	void Start ()
	{
		parent = GameObject.Find ("Projectiles");
		if (!parent) {
			Debug.LogError("No Projectiles Game Object");
		}

		FindMySpawner();

		animator = GetComponent<Animator>();
	}

	void Update ()
	{
		if (AttackersAhead ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	private bool AttackersAhead ()
	{
		foreach (Transform attacker in mySpawner.transform) {
			if (attacker.position.x > transform.position.x) {
				return true;
			}
		}
		return false;
	}

	private void Fire() {
		GameObject newProjectile = Instantiate(projectile);
		Transform gun = transform.Find("Gun");
		newProjectile.transform.position = gun.position;
		newProjectile.transform.transform.parent = parent.transform;
	}

	private void FindMySpawner ()
	{
		foreach (Spawner sp in GameObject.FindObjectsOfType<Spawner>()) {
			if (sp.transform.position.y == transform.position.y) {
				mySpawner = sp;
			}
		}

		if (!mySpawner) {
			Debug.LogError("Didn't find my Spawner");
		}
	}
}
