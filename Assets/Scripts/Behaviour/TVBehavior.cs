using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVBehavior : MonoBehaviour {
    public GameObject screenLight;

    void Start()
    {
        turnOff();
    }

    public void turnOn()
    {
        screenLight.SetActive(true);
    }

    public void turnOff()
    {
        screenLight.SetActive(false);
    }
}
