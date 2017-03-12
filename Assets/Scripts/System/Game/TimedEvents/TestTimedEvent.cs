using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimedEvent : TimedEvent {
    private string debug;

    public TestTimedEvent(GameTime executionTime, string debug) : base(executionTime) {
        this.debug = debug;
    }

    public TestTimedEvent(GameTime executionTime, string debug, int executionTimes) : base(executionTime, executionTimes) {
        this.debug = debug;
    }

    protected override void performAction(Game game)
    {
        Debug.Log(debug);
    }
}
