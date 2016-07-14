using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void loadLevel (string level) {
		Debug.Log("Loading level requested: " + level);
		SceneManager.LoadScene(level);
	}	

	public void quitGame () {
		Debug.Log("Quiting Game");
		Application.Quit();
	}
}