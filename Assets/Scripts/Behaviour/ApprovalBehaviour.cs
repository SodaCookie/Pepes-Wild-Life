using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApprovalBehaviour : MonoBehaviour {

	private Game game;

	// Use this for initialization
	void Awake () {
		game = Game.instance ();
	}

	// Update is called once per frame
	void Update () {
		float approval = game.getCurrentEntertainment ();
		float a = 0.8f;
		float b = 150f;
		float y = 0.008f;
		float percentage = Mathf.Clamp(a * Mathf.Exp(-b * Mathf.Exp(-y * approval)) + 0.1f, 0f, 1f);
		print (percentage);
		// 490 is the furtherest seen value
		transform.localPosition = new Vector3 ((1f - percentage) * -490f, transform.localPosition.y, transform.localPosition.z);
	}
}
