using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVAction : Action {
    private Room targetRoom;
    private TVBehavior tv;

    public TVAction(Room targetRoom, TVBehavior tv)
    {
        entertainmentValue = 15;
        suspiciousness = 5;
        cost = 50;
        this.targetRoom = targetRoom;
        this.tv = tv;
    }

    protected override void performAction(Game game)
    {
        Node roomNode = targetRoom.gameObject.GetComponent<Node>();
        tv.turnOn();
        game.pepe.AddGoal(new CallbackGoal(tv.turnOff));
        game.pepe.AddGoal(new MoveToNodeGoal(roomNode, 3));
    }
}
