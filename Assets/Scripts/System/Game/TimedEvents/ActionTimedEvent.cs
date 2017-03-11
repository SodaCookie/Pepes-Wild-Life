using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTimedEvent : TimedEvent {
    private Action action;

    public ActionTimedEvent(GameTime executionTime, Action action) : base(executionTime) {
        this.action = action;
    }
    public ActionTimedEvent(GameTime executionTime, Action action, int executionTimes) : base(executionTime, executionTimes) {
        this.action = action;
    }

    protected override void performAction(Game game)
    {
        action.execute(game);
    }
}
