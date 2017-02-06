using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson; // NEED THIS TO USE THE RigidbodyFirstPersonController SCRIPT ATTACHED TO RigidBodyFPSController FROM THE UNITY STANDARD ASSETS

public class CameraTrigger : MonoBehaviour 
{
	public Transform targetToLookAt; // Drag-in the target object in the Inspector

	private GameObject mainCamera;
	private GameObject player;
	private RigidbodyFirstPersonController FPController;

	// Use this for initialization
	void Start () 
	{
		mainCamera = GameObject.FindWithTag("MainCamera"); // Sets the main camera to variable mainCamera by finding its tag
		player = GameObject.FindWithTag("Player"); // Finds the player
		FPController = player.GetComponent<RigidbodyFirstPersonController> ();
		//RFC = player.GetComponent<RigidbodyFirstPersonController> ();
	}

	void OnTriggerStay(Collider other) // While player is still in the trigger
	{
		if (other.tag == "Player") 
		{
			FPController.forcedLook = true;
			mainCamera.transform.LookAt(targetToLookAt);
			//mainCamera.transform.rotation = Quaternion.SetFromToRotation(gameObject.transform.position, rotateTowards.position);
			//Debug.Log(gameObject.transform.rotation);
		}
	}

	void OnTriggerExit(Collider other) // When player leaves the trigger
	{
		if (other.tag == "Player") 
		{
			FPController.forcedLook = false;
		}
	}
}
