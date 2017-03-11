using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimedEvent : TimedEvent {
    public TestTimedEvent(GameTime executionTime) : base(executionTime) { }

    public TestTimedEvent(GameTime executionTime, int executionTimes) : base(executionTime, executionTimes) { }

    protected override void performAction(Game game)
    {
        Debug.Log("TEST TIMED EVENT");
    }
}
