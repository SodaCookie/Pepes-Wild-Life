using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour {

	public GameTime sunrise; 
	public GameTime highnoon;
	public GameTime sunset;
	public GameTime twilight; 

	private Light[] day_lights; 
	private Light[] night_lights; 

	// Use this for initialization
	void Awake () {
		sunrise = new GameTime (-1, -1, 5, 0, 0);
		highnoon = new GameTime (-1, -1, 12, 0, 0);
		sunset = new GameTime (-1, -1, 20, 0, 0);
		twilight = new GameTime (-1, -1, 23, 59, 59);

//		foreach (Transform child in GameObject.Find("DayLights").transform) {
//		}
//
//		foreach (Transform child in GameObject.Find("NightLights").transform) {
//		}
	}
	
	// Update is called once per frame
	void Update () {
//		GameTime curtime = Game.instance ().getCurrentGameTime ();
//		if (curtime < sunrise) {
//			
//		} else if (curtime < highnoon) {
//		} else if (curtime < sunset) {
//		} else if (curtime < twilight) {
//		}
	}
}
