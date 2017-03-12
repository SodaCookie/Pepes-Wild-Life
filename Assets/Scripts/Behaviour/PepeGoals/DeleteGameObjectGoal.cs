using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameObjectGoal : PepeGoal {

    private GameObject target;

    public DeleteGameObjectGoal(GameObject target)
    {
        this.target = target;
    }

    public override bool run(PepeBehaviour pepe)
    {
        // Simply deletes the game object
        GameObject.Destroy(target);
        completed = true;
        return true;
    }

    public override void interrupt(PepeGoal goal, PepeBehaviour pepe)
    {

    }
}
