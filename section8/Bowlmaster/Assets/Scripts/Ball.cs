using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float initialSpeed;

	private Rigidbody rigidbody;
	private AudioSource audioSource;
	private Vector3 initial;

	void Start() {
		rigidbody = GetComponent<Rigidbody>();
		rigidbody.useGravity = false;
		initial = this.transform.position;
	}

	public void Launch(Vector3 direction) {
		rigidbody.useGravity = true;
		rigidbody.velocity = direction;
		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
	}

	public void Reset() {
		this.transform.position = initial;

		Rigidbody rb = GetComponent<Rigidbody>();
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.useGravity = false;

		// Reset the camera
		FindObjectOfType<Camera>().Reset();
	}
}
