using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 0.01f;

	public bool isStanding() {
		return (Mathf.Abs(Vector3.Dot(this.transform.up, Vector3.right)) < standingThreshold) &&
		(Mathf.Abs(Vector3.Dot(this.transform.up, Vector3.forward)) < standingThreshold);
	}

	public void RaiseIfStanding (float amount)
	{
		if (isStanding ()) {
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.useGravity = false;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			transform.Translate(Vector3.up * amount); 
		}
	}

	public void LowerIfStanding (float amount)
	{
		if (isStanding ()) {
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.useGravity = true;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			transform.Translate(Vector3.down * amount); 
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
