using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepeGoal {

	public Game game;
	public bool completed = false;

	public PepeGoal() {
		// Search for game
	}

	public virtual void initialize(PepeBehaviour pepe) {
		// Override to change starting calculations
	}

	public virtual bool run(PepeBehaviour pepe) {
		return true;
	}

	public virtual void interrupt(PepeGoal goal, PepeBehaviour pepe) {
		// Override to set interrupt
	}

}
