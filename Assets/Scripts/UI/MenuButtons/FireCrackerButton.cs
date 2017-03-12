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
		"Was that a firecracker?",
        "Dammit Joel! Is that you again?"
	};

    protected override void perform()
    {
        if (!targetRoom)
            Debug.LogError("Target room not set!");

        FireCrackerAction act = new FireCrackerAction(targetRoom);

        // Spawn animation and sound
        if (act.canExecute(Game.instance()))
        {
            if (Game.instance().pepe.room == targetRoom.type)
                act.enhance();
            var firecracker = Instantiate(animation);
            firecracker.transform.position = targetRoom.transform.position;

            // Create message
            Game.instance().pepe.PostMessage(quotes[Random.Range(0, quotes.Length)], 3);
        }

        act.execute(Game.instance());
    }
}
