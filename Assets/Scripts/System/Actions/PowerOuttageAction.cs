using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOuttageAction : Action {
    public PowerOuttageAction()
    {
        entertainmentValue = 25;
        suspiciousness = 5;
        cost = 500;
    }

    protected override void performAction(Game game)
    {
        game.pepe.AddGoal(new WanderGoal(10));
    }
}
