using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour, Interactable {
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
        // Add interactions that should work on the house
    }
}
