using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallbackGoal : PepeGoal {

    private System.Action call_back;

    public CallbackGoal(System.Action call_back)
    {
        this.call_back = call_back;
    }

    public override bool run(PepeBehaviour pepe)
    {
        // Simply calls the callback
        call_back.Invoke();
        completed = true;
        return true;
    }

    public override void interrupt(PepeGoal goal, PepeBehaviour pepe)
    {

    }
}
