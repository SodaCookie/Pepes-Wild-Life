using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePepeMessageTimedEvent : TimedEvent {
    public static int CUR_ID = 0;

    private int my_id;

    public RemovePepeMessageTimedEvent(GameTime executionTime) : base(executionTime) {
        my_id = CUR_ID;
        CUR_ID++;
    }

    public RemovePepeMessageTimedEvent(GameTime executionTime, int executionTimes) : base(executionTime, executionTimes) { }

    protected override void performAction(Game game)
    {
        Debug.Log(my_id);
        game.pepe.RemoveMessage();
    }
}
