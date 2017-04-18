﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinnerAndTableTask : MonoBehaviour {
	private bool onetimeTaskCompletion;
	private GameManager gameManagerScript;

	// Use this for initialization
	void Start () {
		onetimeTaskCompletion = false;
		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

	}
	/* This is the script that activates NormalTaskCompleted() when the sandwiches and cookies are placed*/
	// Update is called once per frame
	void Update () {
		if(onetimeTaskCompletion == false)
		{
			if (HoldAndSetCookies.areCookiesCooked == true && HoldAndSetSandwiches.areSandwichesPlaced == true) {
				gameManagerScript.NormalTaskCompleted ();
				onetimeTaskCompletion = true;
			}
		
	}
}
}
