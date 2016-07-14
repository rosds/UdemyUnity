using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	int min, max, guess;

	// Use this for initialization
	void Start () {
		startGame();
	}

	void startGame() {
		initGame();
		print("=====================================================");
		print("Welcome to Number Wizard");
		print("pick a number in your head, but don't tell me!");
		print("The highest number you can pick is: " + max);
		print("The lowest number you can pick is: " + min);

		max += 1;

		print("Is your number " + guess + "?");
		print("up: higher - down: lower - enter: equal");
	}

	void nextGuess () {
		guess = (max + min) / 2;
		print("Is your number " + guess + "?");
	}

	void initGame () {
		max = 1000;
		min = 1;
		guess = 500;
	}
	
	// Update is called once per frame
	void Update () {
		// keyCode.UpArrow == "up"
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			print("up key pressed");
			min = guess;
			nextGuess();
		} else if (Input.GetKeyDown ("down")) {
			print("down key pressed");
			max = guess;
			nextGuess();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			print("I win!");
			startGame();
		}

	}
}
