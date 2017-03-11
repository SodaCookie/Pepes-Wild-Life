using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderGoal : PepeGoal {

	private float speed;

	public WanderGoal(float speed = 0.2f) {
		this.speed = speed;
	}

	public override bool run(PepeBehaviour pepe) {
		// Simply moves pepe to the goal
		Pathing p = GameObject.Find("Pathing").GetComponent<Pathing>();
		int n = Random.Range (0, p.nodes.Count - 1);
		pepe.AddGoal(new MoveToNodeGoal(p.nodes[n], speed));
		return true;
	}
}
