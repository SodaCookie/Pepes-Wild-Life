using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action {
    // You should set these in the constructor of the derived class
    protected float entertainmentValue = 0;
    protected float suspiciousness = 0;
    protected float cost = 0;

    public Action() { }

    public bool execute(Game game)
    {
        if (canExecute(game))
        {
            performAction(game);
            game.lastActionExecutionTime = Time.time;
            game.addEntertainment(entertainmentValue);
            game.addSuspicion(suspiciousness);
            game.spendMoney(cost);
            return true;
        }
        return false;
    }
	
    protected virtual void performAction(Game game)
    {
        // Perform the acction here
    }

    public bool canExecute(Game game)
    {
        return game.getCurrentWealth() >= cost;
    }
}
