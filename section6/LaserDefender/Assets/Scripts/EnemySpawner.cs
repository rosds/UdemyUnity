using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemy;
	public float width = 8f;
	public float height = 6f;

	private Vector3 leftMost, rightMost;
	private float speed = 5f;
	private bool movingLeft = true;

	void spawnEnemies() {
		foreach (Transform child in transform) {
			GameObject new_enemy = Instantiate (enemy, child.position, Quaternion.identity) as GameObject;
			new_enemy.transform.parent = child;	
		}
	}
	
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		SpawnSingleEnemy();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (movingLeft) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		float leftBoundary = transform.position.x - 0.5f * width;
		float rightBoundary = transform.position.x + 0.5f * width;

		if (rightBoundary > rightMost.x) {
			movingLeft = true;	
		} else if (leftBoundary < leftMost.x) {
			movingLeft = false;	
		}

		if (AllDead ()) {
			SpawnSingleEnemy();
		}
	}

	void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}

	void SpawnSingleEnemy ()
	{
		Transform position = NextFreePosition ();
		if (position) {
			GameObject new_enemy = Instantiate (enemy, position.position, Quaternion.identity) as GameObject;
			new_enemy.transform.parent = position;

			if (NextFreePosition ()) {
				Invoke("SpawnSingleEnemy", 0.2f);
			}
		}
	}

	Transform NextFreePosition() {
		foreach (Transform enemy in transform) {
			if (enemy.childCount <= 0) {
				return enemy;
			}
		}
		return null;
	}

	bool AllDead ()
	{
		foreach (Transform enemy in transform) {
			if (enemy.childCount > 0) {
				return false;
			}
		}
		return true;
	}
}
