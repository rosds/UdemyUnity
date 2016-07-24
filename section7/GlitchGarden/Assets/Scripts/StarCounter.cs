using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarCounter : MonoBehaviour {

	public int stars;
	public enum Status {SUCCESS, FAILURE};
	private Text text;

	void Start() {
		text = GetComponent<Text>();
		UpdateDisplay();
	}

	public void AddStars(int number) {
		stars += number;
		UpdateDisplay();
	}

	public Status UseStars (int number)
	{
		if (stars >= number) {
			stars -= number;
			UpdateDisplay ();
			return Status.SUCCESS;
		}

		return Status.FAILURE;
	}

	private void UpdateDisplay() {
		text.text = stars.ToString();
	}
}
