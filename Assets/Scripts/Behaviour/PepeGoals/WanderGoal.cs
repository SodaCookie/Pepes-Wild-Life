using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderGoal : PepeGoal {

	public override bool run(PepeBehaviour pepe) {
		// Simply moves pepe to the goal
		pepe.speed = 0.1f;
		Pathing p = GameObject.Find("Pathing").GetComponent<Pathing>();
		int n = Random.Range (0, p.nodes.Count - 1);
		pepe.AddGoal(new MoveToNodeGoal(p.nodes[n]));
		return true;
	}
}
