using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WaterPlant : MonoBehaviour {
	private GameManager gameManagerScript;
	private GameObject wateringCan;
	private ParticleSystem water;
	private GameObject text;
	private GameObject stickyNote;
	public GameObject canRef;
	private RigidbodyFirstPersonController rigidbodyFirstPersonControllerScript;


	// Use this for initialization
	void Start () {
		stickyNote = GameObject.Find ("StickyNoteWaterPlants");
		text = GameObject.Find("WaterPlantText"); // Gets the child object called 3DText.
		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		wateringCan = GameObject.Find ("wateringCan");
		rigidbodyFirstPersonControllerScript = GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>();
		water = GameObject.Find("WaterParticleEffectPlant").GetComponent<ParticleSystem>();
		water.Stop ();

	}
	
	// Update is called once per frame
	void Activate()  {
					water.Play ();
					StartCoroutine (PlayWater ());

				
			}

	private IEnumerator PlayWater()
	{
		rigidbodyFirstPersonControllerScript.enabled = false; // Disables movement
		yield return new WaitForSeconds (2.5f);
		wateringCan.SetActive (false);
		water.Stop ();
		text.GetComponent<MeshRenderer> ().enabled  = false;
		gameObject.GetComponent<BoxCollider> ().enabled = false;
		stickyNote.GetComponent<MeshRenderer> ().enabled = false;
		Invoke("EnableMovement", 0.5f);
		gameManagerScript.NormalTaskCompleted ();
	}
	private void EnableMovement()
	{
		rigidbodyFirstPersonControllerScript.enabled = true; // Enables Movement
		canRef.active = true;

	}
}


	

