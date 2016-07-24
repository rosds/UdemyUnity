using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {
	private Ball ball;
	private Vector3 positionStart;
	private float timeStart;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();	
	}

	public void DragStart() {
		positionStart = Input.mousePosition;
		timeStart = Time.time;
	}

	public void DragEnd() {
		Vector3 positionEnd = Input.mousePosition;
		float timeEnd = Time.time;
		float deltaTime = timeEnd - timeStart;
		Vector3 deltaPosition = positionEnd - positionStart;
		float tmp = deltaPosition.y;
		deltaPosition.y = deltaPosition.z;
		deltaPosition.z = tmp;

		ball.Launch(deltaPosition / (deltaTime));	
	}
}
