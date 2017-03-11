using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour, Clickable
{
    public List<GameObject> genericMenuButtons = new List<GameObject>();
	public string type = "room";

    public virtual List<GameObject> getButtons()
    {
        return new List<GameObject>(genericMenuButtons);
    }
}
