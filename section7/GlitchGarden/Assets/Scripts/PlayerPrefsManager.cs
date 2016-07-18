using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {
	public enum Difficulty {easy, normal, hard, ultrahard};

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_LEVEL_KEY = "difficulty_level";
	const string LEVEL_KEY = "level_unlocked_";

	public static void setMasterVolume(float volume) {
		volume = Mathf.Max(Mathf.Min(volume, 1f), 0f);
		PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
	}

	public static float getMasterVolume() {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	} 

	public static void setDifficulty (Difficulty d)
	{
		PlayerPrefs.SetInt(DIFFICULTY_LEVEL_KEY, (int)d);
	}

	public static Difficulty getDifficulty ()
	{
		return (Difficulty)PlayerPrefs.GetInt(DIFFICULTY_LEVEL_KEY);
	}

	public static void unlockLevel (int lvl)
	{
		if (lvl >= SceneManager.sceneCountInBuildSettings) {
			Debug.LogError ("invalid level!");
		} else {
			PlayerPrefs.SetInt(LEVEL_KEY + lvl.ToString(), 1); 
		}
	}

	public static bool isLevelUnlocked (int lvl)
	{
		return PlayerPrefs.HasKey(LEVEL_KEY + lvl.ToString());
	}
}
