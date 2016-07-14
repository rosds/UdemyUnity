using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadSec = 0f;

	public void loadNextLevel() {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void loadLevel(string level) {
    	SceneManager.LoadScene(level);
  	}

  	public void quitGame() {
    	Application.Quit();
  	}

  	void Start ()
	{
		if (autoLoadSec > 0f) {
			Invoke("loadNextLevel", autoLoadSec);
		}
  	}
}
