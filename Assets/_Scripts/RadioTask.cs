﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTask : MonoBehaviour {

    private RadioKnob knob;
    private BoxCollider knobBox;
    private RadioPower power;
    private BoxCollider powerBox;
	private GameObject text;
	public Material red;

    

	// Use this for initialization
	void Start () {
        knob = GameObject.Find("RadioKnob").GetComponent<RadioKnob>();
        knob.enabled = false;
        power = GameObject.Find("RadioPower").GetComponent<RadioPower>();
        power.enabled = false;
		text = GameObject.Find("RadioText"); // Gets the child object called 3DText.
		text.GetComponent<MeshRenderer> ().enabled = true;

        knobBox = GameObject.Find("RadioKnob").GetComponent<BoxCollider>();
        knobBox.enabled = false;
        powerBox = GameObject.Find("RadioPower").GetComponent<BoxCollider>();
        powerBox.enabled = false;
    }
	
    private void Activate()
    {
		gameObject.GetComponent<MeshRenderer> ().material = red;
        knob.enabled = true;
        power.enabled = true;
        knobBox.enabled = true;
        powerBox.enabled = true;

    }

    private void CleanUp()
    {
        Invoke("SelfDestruct", 1f);
    }

    private void SelfDestruct()
    {
        gameObject.SetActive(false);
    }
}
