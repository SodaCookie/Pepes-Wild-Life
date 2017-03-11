using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMenu : MonoBehaviour, Navigatable {
    // Public
    [Tooltip("How many buttons are displayed at most in the menu")]
    public int pageSize = 5;
    [Tooltip("How large the menu is")]
    public float radius = 1;
    [Tooltip("Measured in standard degrees. If this is larger than max angle, menu will spawn left to right.")]
    [Range(-360, 360)]
    public float minAngle = 225;
    [Tooltip("Measured in standard degrees. If this is smaller than min angle, menu will spawn left to right")]
    [Range(-360, 360)]
    public float maxAngle = -45;
    [Tooltip("Prefab for next button")]
    public MenuButton nextMenuButton;
    [Tooltip("Prefab for previous button")]
    public MenuButton prevMenuButton;
    [Tooltip("The buttons to display.")]
    public List<MenuButton> menuButtons = new List<MenuButton>();

    // Private
    public List<MenuButton> displayedMenuButtons = new List<MenuButton>();
    private int offset = 0;

	// Use this for initialization
	void Start () {
        UpdateDisplayedMenuButtons();
	}

    public void openMenu()
    {
        gameObject.SetActive(true);
    }

    public void closeMenu()
    {
        gameObject.SetActive(false);
    }

    // Call this to update which buttons are displayed
    void UpdateDisplayedMenuButtons()
    {
        // Get the total number of buttons displayed
        int numMenuButtons = getNumberOfMenuButtonsDisplayed();

        // Clear the list
        ResetDisplayedMenuButtons();

        // Add the previous button
        prevMenuButton.clickable = true;
        if (offset <= 0)
            prevMenuButton.clickable = false;
        displayedMenuButtons.Add(prevMenuButton);

        // Add the buttons currently displayed
        int i;
        for (i = offset; i < offset + numMenuButtons; i++)
        {
            displayedMenuButtons[i].gameObject.SetActive(true);
            displayedMenuButtons.Add(menuButtons[i]);
        }

        // Add the next button
        nextMenuButton.clickable = true;
        if (offset + numMenuButtons >= menuButtons.Count)
            nextMenuButton.clickable = false;
        displayedMenuButtons.Add(nextMenuButton);

        UpdateMenuButtonPositions();
    }

    void ResetDisplayedMenuButtons()
    {
        foreach(MenuButton mb in displayedMenuButtons)
        {
            mb.gameObject.SetActive(false);
        }

        displayedMenuButtons.Clear();
    }

    // Draw the buttons to the correct positions
    void UpdateMenuButtonPositions()
    {
        int index = 0;
        float range = maxAngle - minAngle;
        float degPerIndex = range / (displayedMenuButtons.Count - 1); // -1 because one button will be at position 0

        foreach (MenuButton mb in displayedMenuButtons)
        {
            // Get the center
            Vector3 center = gameObject.transform.position;
            center.z = 0;

            // Calculate the angle for this button
            float angle = minAngle + (degPerIndex * index);

            // Calculate the position
            Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
            direction.Normalize();
            direction = direction * radius;
            mb.gameObject.transform.position = center + direction;

            // Increment the index
            index++;
        }
    }

    int getNumberOfMenuButtonsDisplayed()
    {
        return Mathf.Max(pageSize, menuButtons.Count);
    }

    // Increment buttons by 1
    public void displayNext()
    {
        int endInd = offset + displayedMenuButtons.Count - 1;
        if (endInd + 1 <= menuButtons.Count - 1)
        {
            offset++;
        }
        UpdateDisplayedMenuButtons();
    }

    // Decrement buttons by 1
    public void displayPrevious()
    {
        if (offset - 1 >= 0)
        {
            offset--;
        }
        UpdateDisplayedMenuButtons();
    }

    // Display next page of buttons
    public void displayNextPage()
    {
        int endInd = offset + displayedMenuButtons.Count - 1;
        if (endInd + pageSize > menuButtons.Count - 1)
        {
            offset = (menuButtons.Count - 1) - getNumberOfMenuButtonsDisplayed();
        }
        else
        {
            offset += pageSize;
        }
        UpdateDisplayedMenuButtons();
    }

    // Display previous page of buttons
    public void displayPreviousPage()
    {
        if (offset - pageSize < 0)
        {
            offset = 0;
        }
        else
        {
            offset -= pageSize;
        }
        UpdateDisplayedMenuButtons();
    }
}
