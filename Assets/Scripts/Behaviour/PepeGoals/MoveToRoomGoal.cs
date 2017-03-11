using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToRoomGoal : PepeGoal {

	GameObject target;

	public MoveToRoomGoal(GameObject target) {
		this.target = target;
	}

	public override bool run(PepeBehaviour pepe) {
		// Perform DFS
		return true;
	}
}

