using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricEffectBehaviour : MonoBehaviour {

	private Light light;
	private float count =  1;

	// Use this for initialization
	void Start () {
		light = gameObject.GetComponent<Light> ();
		Destroy (gameObject, gameObject.GetComponent<AudioSource> ().clip.length);
	}

	// Update is called once per frame
	void Update () {
		light.intensity = 8f / count;
		count++;
	}
}
