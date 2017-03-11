using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMessageAction : Action {

	private PepeBehaviour pepe;
	
	public RemoveMessageAction(PepeBehaviour pepe) : base() {
		this.pepe = pepe;
	}

	protected override void performAction(Game game) {
		pepe.RemoveMessage ();
	}
}
