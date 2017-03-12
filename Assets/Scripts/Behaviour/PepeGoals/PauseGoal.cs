using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGoal : PepeGoal {

	private float duration;
	private float start_time;
	private bool interruptable;

	public PauseGoal(float duration, bool interruptable) {
		this.duration = duration;
		this.interruptable = interruptable;
		this.start_time = Time.time;
	}

	public override bool run(PepeBehaviour pepe) {
		if (Time.time - start_time > this.duration) {
			completed = true;
			return true;
		}
		return true;
	}

	public override void interrupt (PepeGoal goal, PepeBehaviour pepe) {
		if (interruptable) {
			completed = true;
		}
	}
}