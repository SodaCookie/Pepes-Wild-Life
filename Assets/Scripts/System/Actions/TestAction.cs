using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAction : Action {
    public TestAction() : base()
    {
        entertainmentValue = 15;
        suspiciousness = 8;
    }

    protected override void performAction(Game game)
    {
        Debug.Log("TEST ACTION FIRED!");
    }
}
