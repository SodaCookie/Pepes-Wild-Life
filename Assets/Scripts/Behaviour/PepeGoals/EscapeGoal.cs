using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeGoal : PepeGoal {

	private PepeGoal curGoal = null;

	public EscapeGoal() {
	}

	public override bool run(PepeBehaviour pepe) {
		if (curGoal == null) {
			pepe.PostMessage ("Screw this! I'm out!", 5);
			curGoal = new MoveToNodeGoal(GameObject.Find("Away").GetComponent<Node>(), 6f);
			pepe.AddGoal (curGoal);
			Game.instance ().gameOver ("He called the police\nNeverlucky");
			return true;
		}
		return true;
	}
}
