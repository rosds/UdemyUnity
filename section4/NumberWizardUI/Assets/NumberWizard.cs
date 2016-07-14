using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	int min, max, guess;
	public Text guessText;
	public int maxTries = 5;

	// Use this for initialization
	void Start () {
		max = 1000;
		min = 1;
		nextGuess();
	}

	void nextGuess () {
		guess = Random.Range(min, max + 1);
		guessText.text = guess.ToString();
	}

	public void guessHigher() {
		checkLose();
		min = guess;
		nextGuess();
	}

	public void guessLower() {
		checkLose();
		max = guess;
		nextGuess();
	}

	void checkLose () {
		maxTries--;
		if (maxTries == 0) {
			SceneManager.LoadScene("Win");
		}
	}
}
