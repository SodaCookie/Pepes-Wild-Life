using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour {

	public GameTime sunrise; 
	public GameTime highnoon;
	public GameTime sunset;
	public GameTime twilight; 

	// Use this for initialization
	void Start () {
		sunrise = new GameTime (-1, -1, 5, 0, 0);
		highnoon = new GameTime (-1, -1, 12, 0, 0);
		sunset = new GameTime (-1, -1, 20, 0, 0);
		twilight = new GameTime (-1, -1, 22, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Game.instance ();
	}
}
