using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

  public void loadLevel(string level) {
    Debug.Log("Loading level requested: " + level);
    Brick.breakableCount = 0;
    SceneManager.LoadScene(level);
  }

  public void quitGame() {
    Debug.Log("Quiting Game");
    Application.Quit();
  }

  public void loadNextLevel() {
    Brick.breakableCount = 0;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void brickDestroyed() {
    if (Brick.breakableCount <= 0) {
      loadNextLevel();
    }
  }
}