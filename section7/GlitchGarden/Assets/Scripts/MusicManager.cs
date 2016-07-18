using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	public void setVolume (float volume)
	{
		audioSource.volume = volume;
	}

	void OnLevelWasLoaded (int lvl)
	{
		Debug.Log("playing musing of level: " + levelMusicChangeArray [lvl]);

		if (levelMusicChangeArray [lvl]) {
			audioSource.clip = levelMusicChangeArray[lvl];
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
