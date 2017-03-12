using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour {

	public GameTime sunrise; 
	public GameTime highnoon;
	public GameTime sunset;
	public GameTime twilight; 

	private List<Light> day_lights; 
	private List<Light> night_lights; 

	private int sunrise_minutes;
	private int highnoon_minutes;
	private int sunset_minutes;
	private int twilight_minutes;

	private bool dayLightDisabled = false;
	private bool nightLightDisabled = false;

	// Use this for initialization
	void Awake () {
		Game.instance ().lighting = this;
		sunrise = new GameTime (-1, -1, 5, 0, 0);
		highnoon = new GameTime (-1, -1, 12, 0, 0);
		sunset = new GameTime (-1, -1, 20, 0, 0);
		twilight = new GameTime (-1, -1, 23, 59, 59);

		// Generate minutes
		sunrise_minutes = sunrise.hour * GameTime.MINUTES_PER_HOUR + sunrise.minute;
		highnoon_minutes = highnoon.hour * GameTime.MINUTES_PER_HOUR + highnoon.minute;
		sunset_minutes = sunset.hour * GameTime.MINUTES_PER_HOUR + sunset.minute;
		twilight_minutes = twilight.hour * GameTime.MINUTES_PER_HOUR + twilight.minute;

		day_lights = new List<Light>(); 
		foreach (Transform child in GameObject.Find("DayLights").transform) {
			day_lights.Add(child.gameObject.GetComponent<Light>());
		}

		night_lights = new List<Light>(); 
		foreach (Transform child in GameObject.Find("NightLights").transform) {
			night_lights.Add(child.gameObject.GetComponent<Light>());
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameTime curtime = Game.instance ().getCurrentGameTime ();
		int cur_minutes = curtime.hour * GameTime.MINUTES_PER_HOUR + curtime.minute;
		if (cur_minutes < sunrise_minutes) {
			// Lerp between the values of curtime and curtime and sunrise
			float w = (float)cur_minutes / (float)sunrise_minutes;
			float night_lights_intensity = Mathf.Lerp (0.6f, 0.0f, w);
			float day_lights_intensity = Mathf.Lerp (0.0f, 0.4f, w);
			if (!nightLightDisabled) {
				foreach (Light light in night_lights) {
					light.intensity = night_lights_intensity;
				}
			}
			if (!dayLightDisabled) {
				foreach (Light light in day_lights) {
					light.intensity = day_lights_intensity;
				}
			}
		} else if (cur_minutes < highnoon_minutes) {
			// Lerp between the values of curtime and curtime and sunrise
			float w = (float)(cur_minutes - sunrise_minutes) / (float)(highnoon_minutes - sunrise_minutes);
			float day_lights_intensity = Mathf.Lerp (0.4f, 1f, w);
			if (!dayLightDisabled) {
				foreach (Light light in day_lights) {
					light.intensity = day_lights_intensity;
				}
			}
		} else if (cur_minutes < sunset_minutes) {
			// Lerp between the values of curtime and curtime and sunrise
			float w = (float)(cur_minutes - highnoon_minutes) / (float)(sunset_minutes - highnoon_minutes);
			float day_red_light = Mathf.Lerp (0.0f, 0.2f, w);
			float day_lights_intensity = Mathf.Lerp (1f, 0.2f, w);
			if (!dayLightDisabled) {
				foreach (Light light in day_lights) {
					light.color = new Color (1f, 1f - day_red_light, 1f - day_red_light);
					light.intensity = day_lights_intensity;
				}
			}
		} else if (cur_minutes < twilight_minutes) {
			// Lerp between the values of curtime and curtime and sunrise
			float w = (float)(cur_minutes - sunset_minutes) / (float)(twilight_minutes - sunset_minutes);
			float day_red_light = Mathf.Lerp (0.2f, 0.0f, w);
			float night_lights_intensity = Mathf.Lerp (0.0f, 0.6f, w);
			float day_lights_intensity = Mathf.Lerp (0.2f, 0.0f, w);
			if (!nightLightDisabled) {
				foreach (Light light in night_lights) {
					light.intensity = night_lights_intensity;
				}
			}
			if (!dayLightDisabled) {
				foreach (Light light in day_lights) {
					light.color = new Color (1f, 1f - day_red_light, 1f - day_red_light);
					light.intensity = day_lights_intensity;
				}
			}
		}
	}

	public void enableDayLight() {
		dayLightDisabled = false;
	}

	public void disableDayLight() {
		dayLightDisabled = true;
		foreach (Light light in day_lights) {
			light.intensity = 0;
		}
	}

	public void enableNightLight() {
		nightLightDisabled = false;
	}

	public void disableNightLight() {
		nightLightDisabled = true;
		foreach (Light light in night_lights) {
			light.intensity = 0;
		}
	}
}
