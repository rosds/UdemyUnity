using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;
	private float speed;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();	
		attacker = GetComponent<Attacker>();
		speed = attacker.walkingSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		GameObject obj = collider.gameObject;

		if (obj.GetComponent<Stone> ()) {
			animator.SetTrigger ("jump");
		} else if (obj.GetComponent<Health>() && !obj.GetComponent<Attacker>()) {
			attacker.Attack(obj);
			animator.SetBool ("isAttacking", true);
		}
	}

	public void Sprint() {
		attacker.walkingSpeed = 1f;
	}

	public void walk ()
	{
		attacker.walkingSpeed = speed;
	}
}
