using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	public int score = 0;
	private Text scoreText;

	public void scorePoints (int points)
	{
		score += points;
	}

	void Start ()
	{
		scoreText = GetComponent<Text>();
	}

	void Update() {
		scoreText.text = score.ToString();
	}
}
