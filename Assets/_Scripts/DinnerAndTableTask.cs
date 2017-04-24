using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinnerAndTableTask : MonoBehaviour {
	private bool onetimeTaskCompletion;
	private GameManager gameManagerScript;
	private GameObject Everyday1task;
	private GameObject StickyNoteMakeDinner;

	// Use this for initialization
	void Start () {
		Everyday1task = GameObject.Find("TempText"); // Gets the child object called 3DText.
		StickyNoteMakeDinner = GameObject.Find("StickyNoteMakeDinner");
		onetimeTaskCompletion = false;
		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

	}
	/* This is the script that activates NormalTaskCompleted() when the sandwiches and cookies are placed*/
	// Update is called once per frame
	void Update () {
		if(onetimeTaskCompletion == false)
		{
			if (HoldAndSetCookies.areCookiesCooked == true && HoldAndSetSandwiches.areSandwichesPlaced == true) {
				Everyday1task.GetComponent<MeshRenderer>().enabled = false;
				StickyNoteMakeDinner.GetComponent<MeshRenderer> ().enabled = false;
				gameManagerScript.NormalTaskCompleted ();
				onetimeTaskCompletion = true;
			}
		
	}
}
}
