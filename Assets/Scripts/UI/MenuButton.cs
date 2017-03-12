using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour {
    public bool clickable = true;
	protected Room targetRoom;

    private Button myUIButton;

	// Use this for initialization
	void Start () {
        myUIButton = gameObject.GetComponent<Button>();
        myUIButton.onClick.AddListener(OnClickHandler);
	}

	// Update is called once per frame
	void Update () {
		// TODO: Visually mask unclickable buttons
	}

	public void setTargetRoom(Room room)
	{
		targetRoom = room;
	}

    public void OnClickHandler()
    {
        if (clickable)
        {
            perform();
        }
    }

    protected virtual void perform()
    {
        // Override this to perform an action on click
    }
}
