using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepeBehaviour : MonoBehaviour {

	public float speed;
	public string room = "outside";
	public LinkedList<PepeGoal> goals;

	private GameObject movingGoal;

	// Use this for initialization
	void Awake () {
		goals = new LinkedList<PepeGoal> ();
		goals.AddLast (new MoveToGoal(GameObject.Find("Garage")));
	}

	// Update is called once per frame
	void Update () {
		bool success = false;
		foreach (PepeGoal goal in goals) {
			success = goal.run (this);
			if (success) {
				break;
			}
		}

		// Remove completed pepe goals
		var cur = goals.First;
		while (cur != null) {
			if (cur.Value.completed) {
				var to_remove = cur;
				cur = cur.Next;
				goals.Remove(to_remove);
			}
			else {
				cur = cur.Next;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Room") {
			room = other.gameObject.GetComponent<Room> ().type;
		}
	}

	void setMoveGoal() {
	}
}
