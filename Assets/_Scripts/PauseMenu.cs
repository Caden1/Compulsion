using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WHATTHEFUCK : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale = 0;
			GameObject.Find ("PausedMenu").GetComponent<Canvas> ().enabled = true;
		}

		
	}

	public void Resume()
	{
		Time.timeScale = 1;
		GameObject.Find ("PausedMenu").GetComponent<Canvas> ().enabled = false;

	}

	public void Restart()
	{
		Application.LoadLevel (Application.loadedLevel );

	}

	public void Quit()
	{
		Application.Quit ();
	}

}
