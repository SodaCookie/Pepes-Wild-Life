using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockWheelBehavior : MonoBehaviour {

	public void OnClickHandler()
    {
        Game.instance().actionMenu.closeMenu();
    }
}
