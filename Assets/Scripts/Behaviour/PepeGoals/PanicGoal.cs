using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicGoal : PepeGoal {

	private float speed;
	private int counter = 0;
	private int previous;
	private string[] possible_dialogs = new string[]{
		"What's going on man?",
		"This has to be some sick joke.",
		"I'm going to call the police.",
		"I'm I seeing things?!?",
		"I'm losing it.",
		"Why is this happening to me.",
		"Whoever you are please just come out.",
		"WHY ME!? WHY ME!?"
	};
	private string[] paranoid_dialogs = new string[]{
		"WTF!!!!!",
		"HOLY LAMB CHOPS!!!",
		"zut.",
		"BOT LANE FED AGAIN!!!",
		"MY POST DIDN'T MAKE FRONT PAGE!",
		"THEY DOWNVOTED MY PEPE!",
		"WHAT IS HAPPENING!!!"
	};

	public PanicGoal(int previous=-1, float speed = 5f) {
		this.speed = speed;
		this.previous = previous;
	}

	public override bool run(PepeBehaviour pepe) {
		// Simply moves pepe to the goal
		bool paranoid = false;
		Pathing p = GameObject.Find("Pathing").GetComponent<Pathing>();
		if (Game.instance ().getCurrentSuspicion() < 75f) {
			Debug.Log ("Decrease Level");
			completed = true;
			Game.instance ().music.pitch = 1.25f;
			return true;
		}
		float roll = Random.value;
		if (roll < 0.6 || previous == -1) {
			Debug.Log ("Moving");
			int n = Random.Range (0, p.nodes.Count - 1);
			previous = n;
			pepe.AddGoal (new MoveToNodeGoal (p.nodes [n], speed));
		}
		else if (roll < 0.8) {
			Debug.Log ("Pacing");
			if (p.nodes [previous].gameObject.GetComponent<Room> ()) { // Only pace in rooms
				pepe.AddGoal (new WaitGoal (Random.Range (5f, 10f), p.nodes [previous], 4f));
			} 
			else {
				Debug.Log ("Moving");
				int n = Random.Range (0, p.nodes.Count - 1);
				previous = n;
				pepe.AddGoal (new MoveToNodeGoal (p.nodes [n], speed));
			}
		}
		else {
			Debug.Log ("Pananoid");
			paranoid = true;
			pepe.AddGoal (new MoveToNodeGoal (p.nodes [previous], speed + 2f));
		}

		// Speech every 5 locations
		counter++;
		if (counter % 5 == 0) {
			if (paranoid) {
				pepe.PostMessage (paranoid_dialogs [Random.Range (0, possible_dialogs.Length)], 3);
			} 
			else {
				pepe.PostMessage (possible_dialogs [Random.Range (0, possible_dialogs.Length)], 3);
			}
		}
		return true;
	}
}
