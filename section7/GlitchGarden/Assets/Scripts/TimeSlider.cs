using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeSlider : MonoBehaviour {

	public float seconds;
	private Slider slider;
	private LevelManager lm;
	private AudioSource audio;
	private bool isTimeUp = false;
	private GameObject youWin;

	void Start() {
		slider = GetComponent<Slider>();
		audio = GetComponent<AudioSource>();
		lm = GameObject.FindObjectOfType<LevelManager>();
		youWin = GameObject.Find("YouWin");
		youWin.SetActive(false);
	}

	void Update ()
	{
		float timeLeft = Time.timeSinceLevelLoad / seconds;
		slider.value = timeLeft;		

		if (timeLeft >= 1f && !isTimeUp) { // Win
			audio.Play();
			Debug.Log(timeLeft);
			Invoke ("WinLevel", audio.clip.length);
			isTimeUp = true;
			youWin.SetActive(true);
		}
	}

	public void WinLevel() {
		lm.loadNextLevel();
	}
}
