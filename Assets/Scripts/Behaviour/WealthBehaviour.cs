using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WealthBehaviour : MonoBehaviour {

	private Game game;

	// Use this for initialization
	void Awake () {
		game = Game.instance ();
	}
	
	// Update is called once per frame
	void Update () {
		float wealth = game.getCurrentWealth ();
		gameObject.GetComponent<UnityEngine.UI.Text> ().text = "$" + Mathf.Floor (wealth).ToString ();
	}
}
