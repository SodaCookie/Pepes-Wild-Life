using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PepeBehaviour : MonoBehaviour {

	public float speed;
	public string room = "outside";
	public LinkedList<PepeGoal> goals;
	private GameObject speech_bubble;

	// Use this for initialization
	void Awake () {
		speech_bubble = GameObject.Find ("Speech Bubble");
		goals = new LinkedList<PepeGoal> ();
		AddGoal (new WanderGoal());
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

	public void AddGoal(PepeGoal goal) {
		if (goals.Count > 0) {
			goals.Last.Value.interrupt (goal, this);
		}
		goals.AddFirst (goal);
		goal.initialize (this);
	}

	public void PostMessage(string message) {
		speech_bubble.GetComponentInChildren<Text> ().text = message;
		speech_bubble.SetActive (true);
	}

	public void RemoveMessage() {
		speech_bubble.SetActive (false);
	}
}
