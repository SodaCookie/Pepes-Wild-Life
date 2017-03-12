using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxiousGoal : PepeGoal {

	private float speed;
	private int counter = 0;
	private int previous;
	private string[] possible_dialogs = new string[]{
		"A lot of weird things going on lately.",
		"Man I gotta lay off the hard stuff for a while",
		"I didn't know I had so many unlit firecrackers.",
		"I got to go finish my work soon.",
		"This house is stupid.",
		"Where did I put that remote...?",
		"God my jimmies are russelled."
	};
	private string[] paranoid_dialogs = new string[]{
		"Is anyone there?",
		"I know someone is here!",
		"Imma kick you so hard your ancestors will feel dizzy!",
		"We can talk about this.",
		"Hey asshole, come out and fight me!"
	};

	public AnxiousGoal(int previous=-1, float speed = 3f) {
		this.speed = speed;
		this.previous = previous;
	}

	public override bool run(PepeBehaviour pepe) {
		// Simply moves pepe to the goal
		bool paranoid = false;
		Pathing p = GameObject.Find("Pathing").GetComponent<Pathing>();
		if (Game.instance ().getCurrentSuspicion() < 50f) {
			completed = true;
			Game.instance ().music.pitch = 1.0f;
			return true;
		}
		if (Game.instance ().getCurrentSuspicion() > 75f) {
			Game.instance ().music.pitch = 1.6f;
			pepe.AddGoal (new PanicGoal ());
			return true;
		}
		float roll = Random.value;
		if (roll < 0.6 || previous == -1) {
			int n = Random.Range (0, p.nodes.Count - 1);
			previous = n;
			pepe.AddGoal (new MoveToNodeGoal (p.nodes [n], speed));
		}
		else if (roll < 0.8) {
			if (p.nodes [previous].gameObject.GetComponent<Room> ()) { // Only pace in rooms
				pepe.AddGoal (new WaitGoal (Random.Range (5f, 10f), p.nodes [previous], 2f));
			} 
			else {
				int n = Random.Range (0, p.nodes.Count - 1);
				previous = n;
				pepe.AddGoal (new MoveToNodeGoal (p.nodes [n], speed));
			}
		}
		else {
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