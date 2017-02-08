using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson; // NEED THIS TO USE THE RigidbodyFirstPersonController SCRIPT ATTACHED TO RigidBodyFPSController FROM THE UNITY STANDARD ASSETS

public class CameraTrigger : MonoBehaviour 
{
	/* (FOR FOCUSING IN ON THE OCD TASK)
	public Transform targetToLookAt; // Drag-in the target object in the Inspector
	*/

	private GameObject mainCamera;
	private GameObject camera2;
	private GameObject player;
	private RigidbodyFirstPersonController FPController;

	// Use this for initialization
	void Start () 
	{
		mainCamera = GameObject.FindWithTag("MainCamera"); // Sets the main camera to variable mainCamera by finding its tag
		camera2 = GameObject.FindWithTag("Camera2"); // Sets the 2nd camera to variable camera2 by finding its tag
		player = GameObject.FindWithTag("Player"); // Finds the player
		FPController = player.GetComponent<RigidbodyFirstPersonController> (); // Gives access to the RigidbodyFirstPersonController script
	}

	void OnTriggerEnter(Collider other) // While player is still in the trigger
	{
		if (other.tag == "Player") 
		{
			ActivateCamera2(); /*(FOR ACTIVATING A 2ND CAMERA TO SEE OCD TASK)*/
			Invoke("ActivateMainCamera", 0.5f); // Calls ActivateMainCamera afer 0.5 seconds. /*(FOR ACTIVATING A 2ND CAMERA TO SEE OCD TASK)*/

			/* (FOR FOCUSING IN ON THE OCD TASK)
			//FPController.forcedLook = true; // Boolean I created in the RigidbodyFirstPersonController script
			//mainCamera.transform.LookAt(targetToLookAt); // Focus on the OCD task
			*/
		}
	}

	void OnTriggerStay(Collider other) // While player is still in the trigger
	{
		if (other.tag == "Player") 
		{
			/* (FOR FOCUSING IN ON THE OCD TASK)
			//FPController.forcedLook = true; // Boolean I created in the RigidbodyFirstPersonController script
			//mainCamera.transform.LookAt(targetToLookAt); // Focus on the OCD task
			*/
		}
	}

	void OnTriggerExit(Collider other) // When player leaves the trigger
	{
		if (other.tag == "Player") 
		{
			/* (FOR FOCUSING IN ON THE OCD TASK)
			// FPController.forcedLook = false;
			*/
		}
	}

	/*(FOR ACTIVATING A 2ND CAMERA TO SEE OCD TASK)*/
	private void ActivateCamera2()
	{
		mainCamera.SetActive(false);
		camera2.SetActive(true);
	}

	/*(FOR ACTIVATING A 2ND CAMERA TO SEE OCD TASK)*/
	private void ActivateMainCamera()
	{
		camera2.SetActive(false);
		mainCamera.SetActive(true);
	}
}
