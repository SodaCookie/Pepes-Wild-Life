using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerAction : Action {
    public SprinklerAction()
    {
        entertainmentValue = 200;
        suspiciousness = 10;
        cost = 200;
    }

    public void enhance()
    {
        entertainmentValue = 250;
        suspiciousness = 15;
    }

    protected override void performAction(Game game)
    {
        Debug.Log(entertainmentValue);
    }
}
