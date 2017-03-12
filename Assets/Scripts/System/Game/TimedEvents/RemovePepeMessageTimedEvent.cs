using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePepeMessageTimedEvent : TimedEvent {
    public RemovePepeMessageTimedEvent(GameTime executionTime) : base(executionTime) { }

    public RemovePepeMessageTimedEvent(GameTime executionTime, int executionTimes) : base(executionTime, executionTimes) { }

    protected override void performAction(Game game)
    {
        game.pepe.RemoveMessage();
    }
}
