using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : PepeGoal {

	GameObject target;

	public MoveToGoal(GameObject target) {
		this.target = target;
	}
	
	public override bool run(PepeBehaviour pepe) {
		// Simply moves pepe to the goal
		pepe.transform.position = Vector3.MoveTowards(pepe.transform.position, target.transform.position, pepe.speed);
		if (pepe.transform.position == target.transform.position) {
			completed = true;
		}
		return true;
	}
}
