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

	public void openMenu() {
		CircleMenu menu = Game.instance ().actionMenu;
		menu.transform.position = Input.mousePosition;
        menu.radius = 50;
        menu.displayWheel = true;
		menu.setMenuButtons (getButtons(), this);
		menu.openMenu ();
	}
}
