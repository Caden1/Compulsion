using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTask : MonoBehaviour {

    private RadioKnob knob;
    private BoxCollider knobBox;
    private RadioPower power;
    private BoxCollider powerBox;
	private FloatingText text;

    

	// Use this for initialization
	void Start () {
        knob = GameObject.Find("RadioKnob").GetComponent<RadioKnob>();
        knob.enabled = false;
        power = GameObject.Find("RadioPower").GetComponent<RadioPower>();
        power.enabled = false;
		text = GameObject.Find("RadioText").GetComponent<FloatingText>(); // Gets the child object called 3DText.

        knobBox = GameObject.Find("RadioKnob").GetComponent<BoxCollider>();
        knobBox.enabled = false;
        powerBox = GameObject.Find("RadioPower").GetComponent<BoxCollider>();
        powerBox.enabled = false;
    }
	
    private void Activate()
    {
        knob.enabled = true;
        power.enabled = true;
        knobBox.enabled = true;
        powerBox.enabled = true;
		text.Activate ();

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
