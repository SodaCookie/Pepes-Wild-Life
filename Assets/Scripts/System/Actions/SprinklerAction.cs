using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerAction : Action {
    public SprinklerAction()
    {
        entertainmentValue = 250;
        suspiciousness = 10;
        cost = 200;
    }

    protected override void performAction(Game game)
    {
        // TODO: Add some action for leaving/avoiding the room
    }
}
