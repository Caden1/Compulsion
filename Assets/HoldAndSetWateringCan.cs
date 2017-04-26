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


		}
	}

	public void SetVarTrue()
	{
		water = true;
	}

}
