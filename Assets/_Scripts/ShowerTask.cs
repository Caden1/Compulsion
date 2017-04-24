using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerTask : MonoBehaviour {
	private ParticleSystem water;
	private GameManager gameManagerScript;
	private GameObject text;
	private GameObject stickyNote;


	// Use this for initialization
	void Start () {
		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		water = GameObject.Find("WaterParticleEffectShower").GetComponent<ParticleSystem>();
		text = GameObject.Find ("ShowerText");
		stickyNote = GameObject.Find ("StickyNoteGoShower");
		water.Stop();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (other.gameObject.name);
		if (other.gameObject.name == "Player") {
			water.Play ();
		}
	}

	void OnTriggerExit(Collider other)
	{
		water.Stop ();
		gameManagerScript.NormalTaskCompleted ();
		stickyNote.GetComponent<MeshRenderer> ().enabled = false;
		text.GetComponent<MeshRenderer> ().enabled = false;
		gameObject.GetComponent<BoxCollider> ().enabled = false;

	}
}
