using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range (0f, 5f)]
	public float walkingSpeed;

	[Range (0f, 100f)]
	public float damage;

	public float spawnRate;

	private bool hold = false;
	private GameObject currentTarget;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hold) {
			transform.Translate (Vector3.left * walkingSpeed * Time.deltaTime);	
		}
	}

	public void Hold()
	{
		hold = true;
	}

	public void Unhold ()
	{
		hold = false;
	}

	public void Attack (GameObject defender)
	{
		currentTarget = defender;
	}

	public void DoDamage ()
	{
		if (!currentTarget) return;

		Health health = currentTarget.GetComponent<Health> ();
		health.ReceiveDamage (damage);
		if (!health.isAlive ()) {
			currentTarget = null;
			animator.SetBool("isAttacking", false);
		}
	}
}
