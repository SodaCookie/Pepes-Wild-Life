using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObject : MonoBehaviour, Clickable
{
    [Tooltip("The room this belongs to")]
    public Room parentRoom;

    public List<GameObject> genericMenuButtons = new List<GameObject>();

    // Returns a copy of our interactions
    public virtual List<GameObject> getButtons()
    {
        List<GameObject> to_ret = new List<GameObject>(genericMenuButtons);
        List<GameObject> parentMenuButtons = parentRoom.getButtons();
        foreach(GameObject b in parentMenuButtons)
        {
            to_ret.Add(b);
        }
        return to_ret;
    }
}
