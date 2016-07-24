using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	public Text text;
	public bool ballEnteredBox = false;
	public float raisePinsHeight = 10.0f;
	public GameObject pinSet;

	private int lastStandingCount;
	private float standingTimer;
	private Ball ball;

	int CountStanding ()
	{
		int total = 0;
		foreach (Pin i in FindObjectsOfType<Pin>()) {
			if (i.isStanding ()) {
				total += 1;
			}
		}
		return total;
	}

	public void RaisePins ()
	{
		Debug.Log("raise");
		foreach (Pin pin in FindObjectsOfType<Pin>()) {
			pin.RaiseIfStanding(raisePinsHeight);	
		}
	}

	public void LowerPins ()
	{
		Debug.Log("lower");
		foreach (Pin pin in FindObjectsOfType<Pin>()) {
			pin.LowerIfStanding(raisePinsHeight);	
		}
	}

	public void spawnNewPins ()
	{
		Instantiate (pinSet);
	}

	void Start ()
	{
		ball = FindObjectOfType<Ball>();
	}

	void Update ()
	{
		text.text = CountStanding ().ToString ();

		if (ballEnteredBox) {
			CheckStanding ();
		}
	}

	void CheckStanding ()
	{
		int currentStandingCount = CountStanding ();

		if (lastStandingCount != currentStandingCount) {
			standingTimer = Time.time;
		} else if (Time.time - standingTimer >= 3.0f) {
			PinsHaveSettled();
		}

		lastStandingCount = currentStandingCount;
	}

	void PinsHaveSettled() {
		text.color = Color.green;
		ballEnteredBox = false;
		ball.Reset();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.GetComponent<Ball> ()) {
			text.color = Color.red;
			ballEnteredBox = true;
			lastStandingCount = CountStanding();
			standingTimer = Time.time;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.transform.parent.gameObject.GetComponent<Pin> ()) {
			Destroy(other.gameObject.transform.parent.gameObject);
		}
	}
}
