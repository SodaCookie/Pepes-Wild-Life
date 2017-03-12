using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFromNodeGoal : PepeGoal {

	private Node target;
	private Pathing pathing;
	private float speed;

	public MoveFromNodeGoal(Node target, float speed = 6f) {
		this.target = target;
		this.speed = speed;
	}

	public override void initialize (PepeBehaviour pepe) {
		pathing = GameObject.Find("Pathing").GetComponent<Pathing>();
	}

	public override bool run(PepeBehaviour pepe) {
		List<Node> choices = new List<Node>();
		while (choices.Count < 4) {
			int n = Random.Range (0, pathing.nodes.Count);
			if (pathing.nodes [n].node != pepe.room) {
				choices.Add(pathing.nodes[n]);
			}
		}
		Node furthest_node = choices [0];
		float furthest_distance = (furthest_node.transform.position - target.transform.position).magnitude;
		for (int i = 1; i < choices.Count; i++) {
			float distance = (choices [i].transform.position - target.transform.position).magnitude;
			if (distance < furthest_distance) {
				furthest_distance = distance;
				furthest_node = choices [i];
			}
		}
		pepe.AddGoal (new MoveToNodeGoal (furthest_node, speed));
		completed = true;
		return true;
	}
}
