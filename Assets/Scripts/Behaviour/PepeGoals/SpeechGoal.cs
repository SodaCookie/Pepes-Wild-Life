using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechGoal : PepeGoal {

	private string message;

	public SpeechGoal(string message) {
		this.message = message;
	}

	public override bool run(PepeBehaviour pepe) {
		// Simply moves pepe to the goal
		pepe.PostMessage(message);
		completed = true;
		return false;
	}
}
