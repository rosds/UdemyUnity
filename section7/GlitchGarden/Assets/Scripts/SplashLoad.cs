using UnityEngine;
using System.Collections;

public class SplashLoad : MonoBehaviour {
	void Update ()
	{
		// Wait 5 seconds and then call next level
		if (Time.realtimeSinceStartup >= 4f) {
			GameObject lm = GameObject.Find ("LevelManager");
			lm.GetComponent<LevelManager>().loadNextLevel();	
		}
	}
}
