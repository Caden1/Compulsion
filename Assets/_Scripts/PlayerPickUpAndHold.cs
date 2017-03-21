﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUpAndHold : MonoBehaviour
{
    private static int itemsCarried;
    private Transform playerCarryPosition;
    private Transform playerPosition;
	public PopUpText tempObj;
	int cnt = 0;

    // Use this for initialization
    void Start()
    {
        playerCarryPosition = GameObject.FindGameObjectWithTag("CarryPosition").transform; // There's an object that's a chld to the Player. This is it's position. For carrying objects
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform; // The players position.

        itemsCarried = 0;
    }

    public void PickUpAndHold(GameObject objectToHold)
    {
        if (itemsCarried == 0) // So only one item can be held at a time
        {
            objectToHold.transform.position = playerCarryPosition.position; // Set the object new position to this one. Close to the player.
            objectToHold.transform.parent = playerPosition; // Make the object a child to the player. For carrying

            itemsCarried++;

            objectToHold.SendMessage("SetVarTrue", SendMessageOptions.DontRequireReceiver); // Set boolean in each script so you can set down items properly.
        }
        Debug.Log("Items Carried; " + itemsCarried);
    }

    public void SetDown()
    {   
        itemsCarried--;
    }
}
