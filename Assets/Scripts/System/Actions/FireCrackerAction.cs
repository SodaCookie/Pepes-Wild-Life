﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCrackerAction : Action {
    private Room targetRoom;

    public FireCrackerAction(Room targetRoom) : base()
    {
        entertainmentValue = 15;
        suspiciousness = 8;
        cost = 100;
        this.targetRoom = targetRoom;
    }

    protected override void performAction(Game game)
    {
        Node roomNode = targetRoom.gameObject.GetComponent<Node>();
        PepeGoal goal = new MoveToNodeGoal(roomNode, 10);
		Debug.Log ("fdsfdsafds");
        game.pepe.AddGoal(goal);
    }
}
