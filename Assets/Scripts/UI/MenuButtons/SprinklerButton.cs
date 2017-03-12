using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinklerButton : MenuButton {

    protected override void perform()
    {
        SprinklerAction act = new SprinklerAction();
        FireActionInteraction inter = new FireActionInteraction(act);
        inter.execute();
    }
}
