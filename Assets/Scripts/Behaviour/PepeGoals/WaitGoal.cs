using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitGoal : PepeGoal {

	private float speed;
	private Node node;
	private float duration;
	private MoveToGoal currentGoal;
	private GameObject target;

	public WaitGoal(float duration, Node node, float speed = 0.2f) {
		this.duration = duration;
		this.node = node;
		this.speed = speed;
	}

	public override bool run(PepeBehaviour pepe) {
		// Simply moves pepe to the goal
		duration -= Time.deltaTime;
		if (duration < 0) {
			completed = true;
			currentGoal = null;
			if (target != null) {
				Object.Destroy (target);
			}
			return true;
		}
		if (currentGoal == null) {
			// Spawn a nearby mini goal
			target = new GameObject();
			pepe.speed = speed;
			target.transform.position = node.transform.position + new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f)).normalized * 0.5f;
			currentGoal = new MoveToGoal (target);
		}
		currentGoal.run (pepe);
		if (currentGoal.completed) {
			currentGoal = null;
			Object.Destroy (target);
		}
		return true;
	}

	public override void interrupt (PepeGoal goal, PepeBehaviour pepe) {
		completed = true;
		currentGoal = null;
		if (target != null) {
			Object.Destroy (target);
		}
	}
}