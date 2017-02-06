using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	private GameObject objectHeld;
	private Ray ray;
	private RaycastHit hit;
	private GameObject camera;

	// Use this for initialization
	void Start ()
	{
		objectHeld = null;
		camera = GameObject.Find("MainCamera"); // Gets the main camera in the scene
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			// Anything for one left click down goes here.
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (Physics.Raycast(ray, out hit))
				{
					objectHeld = hit.collider.gameObject;
				}
			}
		}
		else if (Input.GetMouseButton(0))
		{
			if (objectHeld.tag == "Pickupable")
			{
				objectHeld.SendMessage("PickupDriver", SendMessageOptions.DontRequireReceiver);
				/*
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit))
				{
					objectHeld.SendMessage("Move", hit, SendMessageOptions.DontRequireReceiver);
				}
				*/
			}
		}
		else if (Input.GetMouseButtonUp(0))
		{
			// Anything for one left click up goes here.
		}
	}
}
