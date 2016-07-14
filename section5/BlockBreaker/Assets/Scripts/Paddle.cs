using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

  public bool autoplay = false;
  public Ball ball;

  void Update() {
    if (autoplay) {
      AutoPlay();
    } else {
      MoveWithMouse();
    }
  }

  void AutoPlay() {
    Vector2 ball_position = ball.transform.position;
    this.transform.position = new Vector3(ball_position.x, this.transform.position.y, 0.0f);
  }

  void MoveWithMouse() {
    float mouse_position_in_blocks = Input.mousePosition.x / Screen.width * 16;
    mouse_position_in_blocks = Mathf.Clamp(mouse_position_in_blocks, 0.5f, 15.5f);
    this.transform.position = new Vector3(mouse_position_in_blocks, this.transform.position.y, 0.0f);
  }
}
