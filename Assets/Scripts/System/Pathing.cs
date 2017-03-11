using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour {

	public List<GameObject> gameNodes;
	[HideInInspector] public List<Node> nodes;
	public Dictionary<int, int[]> connections;

	// Use this for initialization
	void Start () {
		nodes = new List<Node> ();
		// Assign Indexes
		for (int i = 0; i < gameNodes.Count; i++) {
			nodes.Add(gameNodes [i].GetComponent<Node> ());
			nodes [i].index = i;
		}

		// Create connections
		connections = new Dictionary<int, int[]> ();
		connections.Add ( 0, new int[]{2});
		connections.Add ( 1, new int[]{2, 4, 14});
		connections.Add ( 2, new int[]{0, 1, 3});
		connections.Add ( 3, new int[]{2, 6});
		connections.Add ( 4, new int[]{1});
		connections.Add ( 5, new int[]{9, 15});
		connections.Add ( 6, new int[]{3, 7, 15, 17});
		connections.Add ( 7, new int[]{6, 8});
		connections.Add ( 8, new int[]{7, 16});
		connections.Add ( 9, new int[]{5});
		connections.Add (10, new int[]{12, 13, 16});
		connections.Add (11, new int[]{17});
		connections.Add (12, new int[]{10});
		connections.Add (13, new int[]{10});
		connections.Add (14, new int[]{1, 18});
		connections.Add (15, new int[]{5, 6});
		connections.Add (16, new int[]{8, 10});
		connections.Add (17, new int[]{6, 11});
		connections.Add (18, new int[]{14});
	}
}
