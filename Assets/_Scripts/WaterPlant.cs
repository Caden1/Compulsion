using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlant : MonoBehaviour {
	private GameManager gameManagerScript;


	// Use this for initialization
	void Start () {
		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Activate()  {
		
				
					gameObject.GetComponent<BoxCollider> ().enabled = false;
					gameManagerScript.NormalTaskCompleted ();
				
			}
		}


	

