using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBehaviour : MonoBehaviour {

	private int midnight_minutes;

	// Use this for initialization
	void Start () {
		midnight_minutes = GameTime.HOURS_PER_DAY * GameTime.MINUTES_PER_HOUR;
	}
	
	// Update is called once per frame
	void Update () {
		GameTime curtime = Game.instance ().getCurrentGameTime ();
		int cur_minutes = curtime.hour * GameTime.MINUTES_PER_HOUR + curtime.minute;
		gameObject.GetComponent<RectTransform> ().rotation = Quaternion.Euler (new Vector3 (0f, 0f, ((float)cur_minutes / (float)midnight_minutes) * 360f));
	}
}
