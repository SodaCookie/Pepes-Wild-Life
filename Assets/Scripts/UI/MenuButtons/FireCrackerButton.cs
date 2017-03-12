using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCrackerButton : MenuButton {

    protected override void perform()
    {
        if (!targetRoom)
            Debug.LogError("Target room not set!");
        FireCrackerAction act = new FireCrackerAction(targetRoom);
        FireActionInteraction inter = new FireActionInteraction(act);
        inter.execute();
    }
}
