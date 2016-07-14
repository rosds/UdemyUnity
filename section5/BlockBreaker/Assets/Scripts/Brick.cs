using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

  private int timesHit;
  private LevelManager levelManager;

  public AudioClip crack;
  public static int breakableCount = 0;
  public Sprite[] spritesArray;
  public bool isBreakable;
  public GameObject smoke;

  // Use this for initialization
  void Start() {
    timesHit = 0;
    levelManager = GameObject.FindObjectOfType<LevelManager>();
    isBreakable = (this.tag == "Breakable");

    if (isBreakable) {
        breakableCount++;
    }
  }
	
  // Update is called once per frame
  void Update() {
	
  }

  void OnCollisionEnter2D(Collision2D ball) {
    AudioSource.PlayClipAtPoint(crack, transform.position);
    timesHit++;
    Debug.Log("Hit! : " + timesHit);

    int maxHits = spritesArray.Length + 1;
    if (timesHit == maxHits) {
      Instantiate(smoke, this.transform.transform.position, Quaternion.identity);

      breakableCount--;
      Destroy(gameObject);
      levelManager.brickDestroyed();
    } else {
      loadSprite();
    }
  }

  void loadSprite() {
    this.GetComponent<SpriteRenderer>().sprite = spritesArray[timesHit - 1];
  }

  void fakeWin() {
    levelManager.loadNextLevel();
  }
}
