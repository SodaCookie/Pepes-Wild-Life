using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneAction : Action {
    private Room targetRoom;
    private GameObject telephoneSoundSource;

    public TelephoneAction(Room targetRoom, GameObject telephoneSoundSource)
    {
        entertainmentValue = 50;
        suspiciousness = 1;
        cost = 100;
        this.targetRoom = targetRoom;
        this.telephoneSoundSource = telephoneSoundSource;
    }

    protected override void performAction(Game game)
    {
        Node roomNode = targetRoom.gameObject.GetComponent<Node>();
        game.pepe.AddGoal(new CallbackGoal(waitCallBack));
        game.pepe.AddGoal(new DeleteGameObjectGoal(telephoneSoundSource));
        game.pepe.AddGoal(new MoveToNodeGoal(roomNode, 10));
    }

    public void waitCallBack()
    {
        Game.instance().pepe.AddGoal(new WaitGoal(15, targetRoom.gameObject.GetComponent<Node>()));
    }
}
