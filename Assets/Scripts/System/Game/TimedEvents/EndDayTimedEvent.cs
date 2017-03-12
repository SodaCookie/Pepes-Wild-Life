using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDayTimedEvent : TimedEvent {
    public EndDayTimedEvent(GameTime executionTime) : base(executionTime) { }

    public EndDayTimedEvent(GameTime executionTime, int executionTimes) : base(executionTime, executionTimes) { }

    protected override void performAction(Game game)
    {
        game.endDay();
    }
}
