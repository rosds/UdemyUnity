using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

  private Paddle paddle;
  private Vector3 paddleToBallVector;
  private Rigidbody2D rigid;
  private bool hasStarted = false;

  void Awake() {
    rigid = GetComponent<Rigidbody2D>();
  }

  // Use this for initialization
  void Start() {
    paddle = GameObject.FindObjectOfType<Paddle>();
    paddleToBallVector = this.transform.position - paddle.transform.position;
  }
	
  // Update is called once per frame
  void Update() {
    if (!hasStarted) {
      this.transform.position = paddle.transform.position + paddleToBallVector;
      if (Input.GetMouseButtonDown(0)) {
        rigid.velocity = new Vector2(4, 16);
        hasStarted = true;
      }	
    }
  }

  void OnCollisionEnter2D(Collision2D collision) {
    if (hasStarted) {
      GetComponent<AudioSource>().Play();

      Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
      GetComponent<Rigidbody2D>().velocity += tweak;
    }
  }
}
