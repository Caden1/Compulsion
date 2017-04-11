using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyNoteGoShower : MonoBehaviour {

	private GameObject ShowerArea;

	// Use this for initialization
	void Start () {
		ShowerArea = GameObject.Find ("ShowerArea");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Activate()
	{
		// ADD SOUND EFFECT FOR RIPPING OFF STICKY NOTE
		// Disable sticky note, but do not destroy it. It's needed by the GameManager.
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		gameObject.GetComponent<BoxCollider>().enabled = false;
		ShowerArea.GetComponent<BoxCollider> ().enabled = true;
	}
}
