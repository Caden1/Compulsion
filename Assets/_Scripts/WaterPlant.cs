﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlant : MonoBehaviour {
	private GameManager gameManagerScript;
	private GameObject wateringCan;
	private ParticleSystem water;
	private FloatingText text;

	// Use this for initialization
	void Start () {

		text = GameObject.Find("WaterPlantText").GetComponent<FloatingText>(); // Gets the child object called 3DText.
		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		wateringCan = GameObject.Find ("wateringCan");
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
		yield return new WaitForSeconds (2.5f);
		wateringCan.SetActive (false);
		water.Stop ();
		text.Deactivate ();
		gameObject.GetComponent<BoxCollider> ().enabled = false;
		gameManagerScript.NormalTaskCompleted ();
	}
		}


	

