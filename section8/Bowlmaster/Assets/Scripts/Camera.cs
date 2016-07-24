using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public Ball ball;

	private Vector3 offset;
	private Vector3 initial;

	// Use this for initialization
	void Start () {
		initial = transform.position;

		// Get offset to the ball
		offset = ball.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (transform.position.z <= 1600) {
			Vector3 position = ball.transform.position;
			position -= offset;
			transform.position = position;
		}
	}

	public void Reset() {
		this.transform.position = initial;
	}
}
