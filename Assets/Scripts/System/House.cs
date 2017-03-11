using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour, Clickable {
    public List<GameObject> genericMenuButtons = new List<GameObject>();

    void Awake()
    {
        Game.instance().house = this; // Register me as the house
    }

    public List<GameObject> getButtons()
    {
        return new List<GameObject>(genericMenuButtons);
    }
}
