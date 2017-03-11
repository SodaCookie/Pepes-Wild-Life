using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : PepeGoal {

	private GameObject target;

	public MoveToGoal(GameObject target) {
		this.target = target;
	}
	
	public override bool run(PepeBehaviour pepe) {
		// Simply moves pepe to the goal
		pepe.transform.position = Vector3.MoveTowards(pepe.transform.position, target.transform.position, pepe.speed * Time.deltaTime);
		if (pepe.transform.position == target.transform.position) {
			completed = true;
		}
		return true;
	}

	public override void interrupt(PepeGoal goal, PepeBehaviour pepe) {
		completed = true;
	}
}
