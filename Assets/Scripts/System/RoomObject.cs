using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObject : MonoBehaviour, Interactable
{
    [Tooltip("The room this belongs to")]
    public Room parentRoom;

    private List<Interaction> genericInteractions = new List<Interaction>();

    void Awake()
    {
        populateGenericInteractions();
    }

    // Returns a copy of our interactions
    public virtual List<Interaction> getInteractions()
    {
        List<Interaction> to_ret = new List<Interaction>(genericInteractions);
        List<Interaction> parentInteractions = parentRoom.getInteractions();
        foreach(Interaction i in parentInteractions)
        {
            to_ret.Add(i);
        }
        return to_ret;
    }

    private void populateGenericInteractions()
    {
        // Add interactions that should work with every room object to the list in this function
    }
}
