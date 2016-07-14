using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

    void Start() {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

	void OnTriggerEnter2D (Collider2D ball) {
		print("Trigger");
		levelManager.loadLevel("Lose");
	}

	void OnCollisionEnter2D(Collision2D ball) {
		print("Collision");
	}
}
