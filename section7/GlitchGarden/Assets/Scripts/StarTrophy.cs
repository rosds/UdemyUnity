using UnityEngine;
using System.Collections;

public class StarTrophy : MonoBehaviour {

	public int stars;
	private StarCounter counter;

	void Start ()
	{
		counter = GameObject.FindObjectOfType<StarCounter>();
	}

	public void GenerateStars() {
		counter.AddStars(stars);
	}
}
