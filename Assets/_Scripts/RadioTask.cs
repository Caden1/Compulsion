using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioTask : MonoBehaviour {

    private RadioKnob knob;
    private BoxCollider knobBox;
    private RadioPower power;
    private BoxCollider powerBox;
    private GameObject text;
    

	// Use this for initialization
	void Start () {
        knob = GameObject.Find("RadioKnob").GetComponent<RadioKnob>();
        knob.enabled = false;
        power = GameObject.Find("RadioPower").GetComponent<RadioPower>();
        power.enabled = false;
        text = transform.Find("3DText").gameObject;
        text.SetActive(false);

        knobBox = GameObject.Find("RadioKnob").GetComponent<BoxCollider>();
        knobBox.enabled = false;
        powerBox = GameObject.Find("RadioPower").GetComponent<BoxCollider>();
        powerBox.enabled = false;
    }
	
    private void Activate()
    {
        knob.enabled = true;
        power.enabled = true;
        text.SetActive(true);
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
