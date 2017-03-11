using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour, Interactable
{
    private List<Interaction> genericInteractions = new List<Interaction>();

    void Awake()
    {
        populateGenericInteractions();
    }

    public List<Interaction> getInteractions()
    {
        return new List<Interaction>(genericInteractions);
    }

    void populateGenericInteractions()
    {
        // Add interactions that should work with every room to the list in this function
    }
}
