using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAndSetWateringCan : MonoBehaviour {

	public static bool water;
	private GameObject WateringCanRef;
	private GameObject weedPlant;
	//private BoxCollider booksCoffeeTablePlaceCollider;
	//private LivingRoomTrigger2 livingRoomTrigger2Script;

	// Use this for initialization
	void Start()
	{
		water = false;

		weedPlant = GameObject.Find ("WeedPlant");
		WateringCanRef = GameObject.Find("wateringCan"); // Need a reference to the original coffee table books.
		//booksCoffeeTablePlaceCollider = GameObject.Find("BooksCoffeeTablePlace").GetComponent<BoxCollider>();
		//livingRoomTrigger2Script = GameObject.Find("LivingRoomTrigger2").GetComponent<LivingRoomTrigger2>();
	}

	public void GrabThenSetDown()
	{
		if (gameObject.name == "wateringCan" && water == false)
		{
			weedPlant.GetComponent<BoxCollider> ().enabled = true;
			WateringCanRef.GetComponent<BoxCollider> ().enabled = false;
			//WateringCanRef.transform.rotation = Quaternion.Euler (-30, 33, transform.rotation.z);
			SendMessage("PickUpAndHold", gameObject, SendMessageOptions.DontRequireReceiver);
			SendMessage("SetDown", SendMessageOptions.DontRequireReceiver);
			//GetComponent<GenericPlaySound>().PlaySoundRandomPitch(.4f); // Play sound for picking up books
			//booksCoffeeTablePlaceCollider.enabled = true; // Enable the placement box collider.
			//Debug.Log ("Here!");
		}
	/*	else if (gameObject.name == "BooksCoffeeTablePlace" && water == true)
		{
			//Debug.Log ("Here!!!");
			SendMessage("SetDown", SendMessageOptions.DontRequireReceiver);

			//Destroy(coffeeTableBooksReference); // Destroy the original coffe table books.

			gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
			gameObject.transform.GetChild(0).GetComponent<GenericPlaySound>().PlaySoundRandomPitch(.4f);
			gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
			gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
			gameObject.transform.GetChild(3).GetComponent<MeshRenderer>().enabled = true;
			water = false;

			booksCoffeeTablePlaceCollider.enabled = false; // Disable the placement box collider.

			livingRoomTrigger2Script.CleanUp();
		}*/
	}

	public void SetVarTrue()
	{
		water = true;
	}
}
