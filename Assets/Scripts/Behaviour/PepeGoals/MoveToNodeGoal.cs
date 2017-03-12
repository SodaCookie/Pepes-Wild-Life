using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToNodeGoal : PepeGoal {

	private Node target;
	private bool dirty;
	private List<int> path;
	private Pathing pathing;
	private MoveToGoal currentGoal;
	private float speed;

	public MoveToNodeGoal(Node target, float speed = 0.02f) {
		this.target = target;
		this.speed = speed;
		path = new List<int> ();
	}

	public override void initialize (PepeBehaviour pepe) {
		pathing = GameObject.Find("Pathing").GetComponent<Pathing>();
		dirty = true;
		currentGoal = null;
	}

	public void search(PepeBehaviour pepe) {
		// Search for nearest node
		float closest_distance = float.MaxValue;
		Node closest_node = null;
		foreach (Node node in pathing.nodes) {
			if (pepe.room == node.node) {
				float magnitude = (pepe.transform.position - node.transform.position).magnitude;
				if (magnitude < closest_distance) {
					closest_distance = magnitude;
					closest_node = node;
				}
			}
		}
		int start = closest_node.index;
		int dest = target.index;
		path = new List<int> ();
		path.Add (start);
		if (!DFS (start, dest, new List<int> (), path)) {
			Debug.Log ("Path not found.");
		}
	}

	private bool DFS(int start, int dest, List<int> visited, List<int> path) {
		if (start == dest) {
			return true;
		}
		visited.Add (start);

		foreach (int node in pathing.connections[start]) {
			if (!visited.Contains (node)) {
				path.Add (node);
				if (DFS(node, dest, visited, path)) {
					// Found the path
					return true;
				}
				path.Remove (node);
			}
		}
		return false;
	}

	public override bool run(PepeBehaviour pepe) {
		if (dirty) {
			pepe.speed = speed;
			search (pepe);
			currentGoal = null;
			dirty = false;
		}
		// Follow path
		if (currentGoal != null) {
			currentGoal.run (pepe);
			if (currentGoal.completed) {
				currentGoal = null;
			}	
		}
		else if (path.Count > 0) {
			Node targetNode = pathing.nodes [path [0]];
			path.Remove (path [0]);
			currentGoal = new MoveToGoal (targetNode.gameObject);
		} 
		else {
			completed = true;
		}
		return true;
	}

	public override void interrupt (PepeGoal goal, PepeBehaviour pepe) {
		dirty = true;
	}
}

