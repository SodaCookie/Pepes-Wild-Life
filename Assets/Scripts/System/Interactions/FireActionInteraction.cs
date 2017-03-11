using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActionInteraction : Interaction {
    private Action action;

    public FireActionInteraction(Action action) : base()
    {
        this.action = action;
    }

    protected override void performInteraction(Game game)
    {
        action.execute(game);
    }
}
