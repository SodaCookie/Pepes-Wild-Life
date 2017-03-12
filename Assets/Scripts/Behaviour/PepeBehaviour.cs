using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PepeBehaviour : MonoBehaviour {

	public float speed;
	public string room = "outside";
	public LinkedList<PepeGoal> goals;
	public GameObject speech_bubble;

	// Use this for initialization
	void Awake () {
        Game.instance().pepe = this;
		goals = new LinkedList<PepeGoal> ();
//		AddGoal (new WaitGoal(5f, GameObject.Find("Office").GetComponent<Node>()));
		AddGoal (new WanderGoal(1f));
//		AddGoal (new MoveToNodeGoal(GameObject.Find("Kitchen").GetComponent<Node>(), 5f));
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
			goals.First.Value.interrupt (goal, this);
		}
		goals.AddFirst (goal);
		goal.initialize (this);
	}

    public void PostMessage(string message, int realSeconds)
    {
        DisplayMessage(message);
        var destroyTime = Game.instance().getCurrentGameTime() + (int)Game.instance().realSecondsToGameSeconds(realSeconds);
        var action_timed_event = new RemovePepeMessageTimedEvent(destroyTime);
        Game.instance().scheduleTimedEvent(action_timed_event);
    }

	private void DisplayMessage(string message) {
		speech_bubble.SetActive (true);
		speech_bubble.GetComponentInChildren<Text> ().text = message;
	}

	public void RemoveMessage() {
		speech_bubble.SetActive (false);
	}
}
