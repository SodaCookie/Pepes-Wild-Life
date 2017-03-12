using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitGoal : PepeGoal {

	private float speed;
	private Node node;
	private float duration;
	private MoveToGoal currentGoal;
	private GameObject target;

	public WaitGoal(float duration, Node node=null, float speed = 0.2f) {
		this.duration = duration;
		this.node = node;
		if (node == null) {
			// Assign room node
			float closest_distance = float.MaxValue;
			Node closest_node = null;
			foreach (Node n in Game.instance().pathing.nodes) {
				if (Game.instance().pepe.room == n.node && n.gameObject.GetComponent<Room>() != null) {
					float magnitude = (Game.instance().pepe.transform.position - n.transform.position).magnitude;
					if (magnitude < closest_distance) {
						closest_distance = magnitude;
						closest_node = node;
					}
				}
			}
			this.node = closest_node;
		}
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