using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerButton : MenuButton {

	public new GameObject animation;

    protected override void perform()
    {
        SprinklerAction act = new SprinklerAction();
        FireActionInteraction inter = new FireActionInteraction(act);
        inter.execute();
		// Spawn animation and sound
		if (act.canExecute(Game.instance()))
		{
			var pepe = Game.instance ().pepe;
			if (pepe.room == targetRoom.type) {
				// Apply move away if in the same room
				pepe.AddGoal (new MoveFromNodeGoal (targetRoom.gameObject.GetComponent<Node> ()));
				Game.instance().pepe.PostMessage("Oh God! What the heck?", 3);
			} else {
				// Move towards slowly
				pepe.AddGoal (new MoveToNodeGoal (targetRoom.gameObject.GetComponent<Node> (), 2f));
				Game.instance().pepe.PostMessage("What is that sprinking noise?", 3);
			}
			// Get room bounds
			Vector3 bounds = targetRoom.gameObject.GetComponent<BoxCollider2D>().bounds.size;
			var sprinklers = Instantiate(animation);
			Destroy (sprinklers, 10f);
			ParticleSystem.ShapeModule new_shape = sprinklers.GetComponent<ParticleSystem> ().shape;
			new_shape.box = new Vector3 (bounds.x - 1f, 1, 1);
			sprinklers.transform.position = targetRoom.transform.position;
		}
    }
}
