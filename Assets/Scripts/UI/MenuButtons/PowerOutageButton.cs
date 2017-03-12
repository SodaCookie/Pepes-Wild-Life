using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOutageButton : MenuButton {

	public GameObject animation;

    protected override void perform()
    {
        PowerOuttageAction act = new PowerOuttageAction();
        FireActionInteraction inter = new FireActionInteraction(act);
		var electric = Instantiate(animation);
		electric.transform.position = new Vector3();
        inter.execute();
    }
}
