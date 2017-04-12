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
	void Update () {
		if ( Input.GetMouseButtonDown (0) )
		{
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast( Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000) && (!(hit.rigidbody==null) || !(hit.collider==null)))
			{
				if(hit.collider.gameObject.name == "WeedPlant")
				{
					gameObject.GetComponent<BoxCollider> ().enabled = false;
					gameManagerScript.NormalTaskCompleted ();
				}
			}
		}
		
	}
}
