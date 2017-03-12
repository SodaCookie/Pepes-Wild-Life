using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLightsTimedAction : TimedEvent {
	
	private bool light_set;
	private bool day_set;

	public SetLightsTimedAction(GameTime executionTime, bool light_set, bool day_set) : base(executionTime) {
		this.light_set = light_set;
		this.day_set = day_set;
	}

	protected override void performAction(Game game)
	{
		if (light_set) {
			if (day_set) {
				game.lighting.enableDayLight();
			} 
			else {
				game.lighting.enableNightLight();
			}
		}
		else {
			if (day_set) {
				game.lighting.disableDayLight();
			} 
			else {
				game.lighting.disableNightLight();
			}
		}
	}
}
