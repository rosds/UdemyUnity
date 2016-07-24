using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsManager : MonoBehaviour {
	public LevelManager lm;
	public Slider volumeSlider;
	public Dropdown difficulty;
	private MusicManager mm;

	// Use this for initialization
	void Start () {
		mm = GameObject.FindObjectOfType<MusicManager>();
		Debug.Log("pref volume: " + PlayerPrefsManager.getMasterVolume());
		volumeSlider.value = PlayerPrefsManager.getMasterVolume();
		difficulty.value = (int)PlayerPrefsManager.getDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		mm.setVolume(volumeSlider.value);
	}

	public void saveAndExit() {
		PlayerPrefsManager.setMasterVolume(volumeSlider.value);
		PlayerPrefsManager.setDifficulty((PlayerPrefsManager.Difficulty)difficulty.value);
		Debug.Log("pref volume: " + PlayerPrefsManager.getMasterVolume());
		lm.loadLevel("Start");
	}
}
