using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction {
    public Interaction() { }

    public void execute()
    {
        performInteraction(Game.instance());
    }

    protected virtual void performInteraction(Game game)
    {
        // Override this to set interaction's behavior
    }
}
