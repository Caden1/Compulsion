using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTableTask : MonoBehaviour {

	private bool onetimeTaskCompletion;
	private GameManager gameManagerScript;
	private FloatingText text;

	// Use this for initialization
	void Start () {
		text = GameObject.Find ("CheckTableText").GetComponent<FloatingText> ();
		onetimeTaskCompletion = false;
		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

	}
	/* This is the script that activates NormalTaskCompleted() when the sandwiches and cookies are placed*/
	// Update is called once per frame
	void Update () {
		if(onetimeTaskCompletion == false)
		{
			
			if (HoldAndSetForksKnives.FKSet == true && HoldAndSetPlates.setPlates == true) {
				text.Deactivate ();
				gameManagerScript.NormalTaskCompleted ();
				onetimeTaskCompletion = true;
			}

		}
	}
}