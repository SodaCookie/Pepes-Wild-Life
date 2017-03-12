using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOutageButton : MenuButton {

    protected override void perform()
    {
        PowerOuttageAction act = new PowerOuttageAction();
        FireActionInteraction inter = new FireActionInteraction(act);
        inter.execute();
    }
}
