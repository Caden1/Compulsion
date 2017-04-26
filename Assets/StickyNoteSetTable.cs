using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyNoteSetTable : MonoBehaviour {

	private GameObject gameManagerObject;
	private GameObject sponge;
	private GameObject plates;
	public GameObject text;
	public Material Red;
	private GameObject forksandKnives;
	private GameObject kitchenTableCollider;
	private KitchenTableCollider kitchenTableColliderScript;



	// Use this for initialization
	void Start()
	{
		text = GameObject.Find ("CheckTableText");
		gameManagerObject = GameObject.Find("GameManager");
		//sponge = GameObject.Find("Sponge");
		plates = GameObject.Find ("2PlatesPickup");
		forksandKnives = GameObject.Find ("ForkKnifePickup");
		kitchenTableCollider = GameObject.Find("KitchenTableCollider");
		kitchenTableColliderScript = GameObject.Find("KitchenTableCollider").GetComponent<KitchenTableCollider>();
		text.GetComponent<MeshRenderer> ().enabled = true;
	}

	public void Activate()
	{
		// ADD SOUND EFFECT FOR RIPPING OFF STICKY NOTE
		// Disable sticky note, but do not destroy it. It's needed by the GameManager.
		//gameObject.GetComponent<MeshRenderer>().enabled = false;
		gameObject.GetComponent<BoxCollider>().enabled = false;
		gameObject.GetComponent<MeshRenderer> ().material = Red;

		// Enable box colliders needed.
		/*if (ScrubTableWithSponge.scrubTable == false) {
			//Only enable the sponge collider if the table hasn't been scrubbed
			sponge.GetComponent<MeshRenderer>().enabled = true;
			sponge.GetComponent<BoxCollider> ().enabled = true;
		}*/		
		plates.GetComponent<BoxCollider>().enabled = true;
		forksandKnives.GetComponent<BoxCollider>().enabled = true;
		kitchenTableColliderScript.MaybeDisableCollider(); // Decrements the static integer

		if (KitchenTableCollider.colliderEnabledCount == 0) { // Only disable the box collider if no other task is using it.
			kitchenTableCollider.GetComponent<BoxCollider> ().enabled = false;

		}
	}
}
