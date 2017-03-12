using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCrackerAction : Action {
    private Room targetRoom;

    public FireCrackerAction(Room targetRoom) : base()
    {
        entertainmentValue = 100;
        suspiciousness = 15;
        cost = 100;
        this.targetRoom = targetRoom;
    }

    public void enhance()
    {
        entertainmentValue = 150;
        suspiciousness = 20;
    }

    protected override void performAction(Game game)
    {
        Node roomNode = targetRoom.gameObject.GetComponent<Node>();
        PepeGoal goal = new MoveToNodeGoal(roomNode, 10);
        game.pepe.AddGoal(goal);
    }
}
