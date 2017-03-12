using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFromNodeGoal : MonoBehaviour {

	private Node target;
	private Pathing pathing;
	private float speed;

	public MoveFromNodeGoal(Node target, float speed = 2f) {
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
			if (pathing.nodes [n]) {
				pathing.nodes [n];
			}
		}
	}

	public override void interrupt (PepeGoal goal, PepeBehaviour pepe) {
		dirty = true;
	}
}
