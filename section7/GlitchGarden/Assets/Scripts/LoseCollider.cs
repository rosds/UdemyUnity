using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager lm;

	void Start ()
	{
		lm = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		lm.loadLevel("Lose");
	}
}
