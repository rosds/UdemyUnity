using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderObject;
	public static GameObject selectedDefender;
	private Button[] buttonArray;

	// Use this for initialization
	void Start () {
		SpriteRenderer img = GetComponent<SpriteRenderer>();
		img.color = Color.black;

		buttonArray = GameObject.FindObjectsOfType<Button>();
	}
	
	void OnMouseDown ()
	{
		foreach (Button btn in buttonArray) {
			btn.GetComponent<SpriteRenderer>().color = Color.black;
		}
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderObject;
	}
}
