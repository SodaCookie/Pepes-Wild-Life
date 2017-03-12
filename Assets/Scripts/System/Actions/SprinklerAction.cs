using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerAction : Action {
    public SprinklerAction()
    {
        entertainmentValue = 25;
        suspiciousness = 5;
        cost = 100;
    }

    protected override void performAction(Game game)
    {
        // TODO: Add some action for leaving/avoiding the room
    }
}
