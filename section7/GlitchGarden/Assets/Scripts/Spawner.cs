using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackersArray;

	void Update ()
	{
		foreach (GameObject thisAttacker in attackersArray) {
			if (isTimeToSpawn(thisAttacker)) {
				Spawn(thisAttacker);
			}
		}
	}

	private void Spawn(GameObject myAttacker) {
		GameObject newAttacker = Instantiate(myAttacker) as GameObject;
		newAttacker.transform.parent = transform;
		newAttacker.transform.position = transform.position;
	}

	private bool isTimeToSpawn(GameObject myAttacker) {
		Attacker attacker = myAttacker.GetComponent<Attacker>();
		float spawnRate = (1 / attacker.spawnRate) * Time.deltaTime;
		return Random.value < spawnRate;
	}
}