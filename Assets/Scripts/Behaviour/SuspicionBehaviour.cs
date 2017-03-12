using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionBehaviour : MonoBehaviour {

	private Game game;

	// Use this for initialization
	void Awake () {
		game = Game.instance ();
	}
	
	// Update is called once per frame
	void Update () {
		float suspicion = game.getCurrentSuspicion ();
		float percentage = Mathf.Clamp(suspicion / Game.MAX_SUSPICION, 0f, 1f);
		// 490 is the furtherest seen value
		transform.localPosition = new Vector3 ((1f - percentage) * -490f, transform.localPosition.y, transform.localPosition.z);
	}
}
