using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction {
    public Interaction() { }

    public void execute(Game game)
    {
        performInteraction(game);
    }

    protected virtual void performInteraction(Game game)
    {
        // Override this to set interaction's behavior
    }
}
