using System.Collections;
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
	
	// Update is called once per frame
	void Update () {
		if(onetimeTaskCompletion == false)
		{
			if (HoldAndSetCookies.areCookiesCooked == true && HoldAndSetForksKnives.FKSet == true && HoldAndSetPlates.setPlates == true && HoldAndSetSandwiches.areSandwichesPlaced == true) {
				gameManagerScript.NormalTaskCompleted ();
				onetimeTaskCompletion = true;
			}
		
	}
}
}
