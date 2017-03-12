using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCrackerButton : MenuButton {

	public new GameObject animation;

	private string[] quotes = new string[] {
		"What's going on?!?",
		"What in tarnation!",
		"What was that!?!",
		"Holy Jebus, what was that?",
		"Was that a gunshot?",
		"Was that a firecracker?"
	};

    protected override void perform()
    {
        if (!targetRoom)
            Debug.LogError("Target room not set!");
        FireCrackerAction act = new FireCrackerAction(targetRoom);
        FireActionInteraction inter = new FireActionInteraction(act);
        inter.execute();

		// Spawn animation and sound
		var firecracker = Instantiate(animation);
		firecracker.transform.position = targetRoom.transform.position;

		// Create message
		Game.instance().pepe.PostMessage (quotes [Random.Range (0, quotes.Length - 1)], 3);
    }
}
