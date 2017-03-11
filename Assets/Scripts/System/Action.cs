using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {
    // You should set these in the constructor of the derived class
    private float entertainmentValue = 0;
    private float suspiciousness = 0;

    public Action() { }

    public void execute(Game game)
    {
        game.addEntertainment(entertainmentValue);
        game.addSuspicion(suspiciousness);
        performAction(game);
    }
	
    protected virtual void performAction(Game game)
    {
        // Perform the acction here
    }
}
