using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBehaviour : MonoBehaviour {

	private bool transitioning = false;
	private bool cue_in = false;
	private float t = 0.0f;
	private float step = 0.01f;
	public bool finished = true;
	private float max = 1.5f;

	public UnityEngine.UI.Text text;
	public UnityEngine.UI.Image panel1;
	public UnityEngine.UI.Image panel2;

	void Awake () {
		Game.instance().transition = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (transitioning) {
			if (cue_in) {
				t = Mathf.Clamp (t + step, 0.0f, max);
			} else {
				t = Mathf.Clamp (t - step, 0.0f, max);
			}
			if (cue_in && t == max) {
				cue_in = false;
				Game.instance ().startNextDay ();
			} else if (!cue_in && t == 0.0f) {
				transitioning = false;
				finished = true;
				gameObject.GetComponent<RectTransform>().position = new Vector3 (-900f, 0f, 0f);
			}

			float w = Mathf.Clamp (t, 0.0f, 1.0f);
			text.color = new Color (1.0f, 1.0f, 1.0f, t / max);
			panel1.color = new Color (0.0f, 0.0f, 0.0f, w);
			panel2.color = new Color (0.5f, 0.5f, 0.5f, w * 0.2f);
			Game.instance ().music.volume = 1.0f - w;
		}
	}

	public void BeginTransition() {
		GameObject.Find ("TransitionText").GetComponent<UnityEngine.UI.Text> ().text = "Day " + (Game.instance ().getCurrentGameTime ().day + 1).ToString ();
		transitioning = true;
		cue_in = true;
		finished = false;
		t = 0.0f;
		gameObject.GetComponent<RectTransform>().position = new Vector3 ();
	}
}
