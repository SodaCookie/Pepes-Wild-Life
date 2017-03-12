using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOutageButton : MenuButton {

	public new GameObject animation;

    protected override void perform()
    {
        PowerOuttageAction act = new PowerOuttageAction();
        FireActionInteraction inter = new FireActionInteraction(act);
		if (act.canExecute(Game.instance())) {
			var electric = Instantiate(animation);
			electric.transform.position = new Vector3();
			inter.execute();
		}
    }
}
