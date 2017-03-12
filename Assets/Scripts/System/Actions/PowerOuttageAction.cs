using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOuttageAction : Action {
    public PowerOuttageAction()
    {
        entertainmentValue = 400;
        suspiciousness = 10;
        cost = 500;
    }

    protected override void performAction(Game game)
    {
		game.pepe.AddGoal(new TimedGoal(new ForcedPanicGoal(), 2f));
		game.lighting.disableNightLight ();
		var triggerTime = Game.instance().getCurrentGameTime() + (int)Game.instance().realSecondsToGameSeconds(10);
		var action_timed_event = new SetLightsTimedAction(triggerTime, true, false);
		Game.instance().scheduleTimedEvent(action_timed_event);
    }
}
