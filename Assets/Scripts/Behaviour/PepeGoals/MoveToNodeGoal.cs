using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToNodeGoal : PepeGoal {

	private GameObject target;
	private bool dirty;

	public MoveToNodeGoal(GameObject target) {
		this.target = target;
	}

	public override void initialize () {
		dirty = false;
	}

	public void search(PepeBehaviour pepe) {
//		// Search for nearest node
//		float closest_distance = float.MaxValue;
//		Node closest_node = null;
//		Pathing pathing = GameObject.Find("Pathing").GetComponent<Pathing>();
//		foreach (Node node in pathing.nodes) {
//			if (pepe.room == node.node) {
//				float magnitude = (pepe.transform.position - node.transform.position).magnitude;
//				if (magnitude < closest_distance) {
//					closest_distance = magnitude;
//					closest_node = node;
//				}
//			}
//		}
//		closest_node.index;
//
//		//		Stack<int> stack = new Stack<int>();
//		List<int> visited = new List<int>();
//		//		stack.Push ();
//		int cur;
	}

	public override bool run(PepeBehaviour pepe) {


		return true;
	}

	public override void interrupt (PepeGoal goal) {
		
	}
}

