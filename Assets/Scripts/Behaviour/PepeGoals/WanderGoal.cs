using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderGoal : PepeGoal {

	private float speed;
	private int counter = 0;
	private string[] possible_dialogs = new string[]{
		"What a beautiful day.",
		"I wonder if it's raining?",
		"I should probably clean...",
		"I smell OK.",
		"I dealt it. It was me!",
		"And just like that. Pepe springs into action!"
	};

	public WanderGoal(float speed = 0.2f) {
		this.speed = speed;
	}

	public override bool run(PepeBehaviour pepe) {
		// Simply moves pepe to the goal
		Pathing p = GameObject.Find("Pathing").GetComponent<Pathing>();
		int n = Random.Range (0, p.nodes.Count - 1);
		pepe.AddGoal(new MoveToNodeGoal(p.nodes[n], speed));

		// Speech every 5 locations
		counter++;
		if (counter % 5 == 0) {
			pepe.PostMessage (possible_dialogs [Random.Range (0, possible_dialogs.Length - 1)]);
			var action = new RemoveMessageAction (pepe);
			var cur_game_time = Game.instance ().getCurrentGameTime ();
			for (int i = 0; i < 10; i++) {
				cur_game_time++;
			}
			var action_timed_event = new ActionTimedEvent(cur_game_time, action);
			Game.instance ().scheduleTimedEvent (action_timed_event);
		}
		return true;
	}
}
