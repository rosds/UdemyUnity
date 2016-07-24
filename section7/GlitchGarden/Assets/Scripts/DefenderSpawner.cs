using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera cam;
	private StarCounter counter;

	void Start ()
	{
		counter = GameObject.FindObjectOfType<StarCounter>().GetComponent<StarCounter>();
	}

	void OnMouseDown ()
	{
		Defender def = Button.selectedDefender.GetComponent<Defender> ();

		if (counter.UseStars (def.starCost) == StarCounter.Status.SUCCESS) {
			Vector3 mouse = Input.mousePosition;
			Vector3 pos = cam.ScreenToWorldPoint(mouse);

			Vector3 cell;
			cell.x = Mathf.RoundToInt(pos.x);
			cell.y = Mathf.RoundToInt(pos.y);
			cell.z = -0.5f;

			GameObject newDefender = Instantiate(Button.selectedDefender, cell, Quaternion.identity) as GameObject;
			newDefender.transform.parent = GameObject.Find("Defenders").transform; 
		}
	}
}
