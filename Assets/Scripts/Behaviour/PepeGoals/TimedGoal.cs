using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedGoal : PepeGoal {

	private float duration;
	private float start_time;
	private PepeGoal goal;

	public TimedGoal(PepeGoal goal, float duration) {
		this.duration = duration;
		this.goal = goal;
		this.start_time = Time.time;
	}

	public override bool run(PepeBehaviour pepe) {
		// Simply moves pepe to the goal
		if (Time.time - start_time > this.duration) {
			completed = true;
			return true;
		}
		goal.run (pepe);
		if (goal.completed) {
			completed = true;
		}
		return true;
	}

	public override void interrupt (PepeGoal goal, PepeBehaviour pepe) {
		goal.interrupt (goal, pepe);
	}
}