using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseWheelBehavior : MonoBehaviour {

	public void OnClickHandler()
    {
        var menu = Game.instance().actionMenu;
        menu.transform.position = transform.position;
        menu.radius = 80;
        menu.displayWheel = false;
        menu.setMenuButtons(Game.instance().house.getButtons());
        menu.openMenu();
    }
}
