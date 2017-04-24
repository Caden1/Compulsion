using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTableTask : MonoBehaviour {

	private bool onetimeTaskCompletion;
	private GameManager gameManagerScript;
	private GameObject text;
	private GameObject stickyNote;
	// Use this for initialization
	void Start () {
		stickyNote = GameObject.Find ("StickyNote");
		text = GameObject.Find ("CheckTableText");
		onetimeTaskCompletion = false;
		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

	}
	/* This is the script that activates NormalTaskCompleted() when the sandwiches and cookies are placed*/
	// Update is called once per frame
	void Update () {
		if(onetimeTaskCompletion == false)
		{
			
			if (HoldAndSetForksKnives.FKSet == true && HoldAndSetPlates.setPlates == true) {
				text.GetComponent<MeshCollider> ().enabled = false;
				stickyNote.GetComponent<MeshRenderer> ().enabled = false;
				gameManagerScript.NormalTaskCompleted ();
				onetimeTaskCompletion = true;
			}

		}
	}
}