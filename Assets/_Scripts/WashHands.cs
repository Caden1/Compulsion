using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashHands : MonoBehaviour
{
    private SinkKnob sinkKnobScript;
    private bool stopWashingHands;

    private OCDEffectManager blur;

    public AudioClip washingHands;
    public float washingHandsVolume = 0.5f;
    private AudioSource audio;

    // Use this for initialization
    void Start ()
    {
        GameObject sinkKnob = GameObject.Find("SinkKnob");

        sinkKnobScript = sinkKnob.GetComponent<SinkKnob>();

        stopWashingHands = false;

        audio = GetComponent<AudioSource>();

        blur = GameObject.Find("OCDEffectManager").GetComponent<OCDEffectManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (stopWashingHands == false && sinkKnobScript.IsOpen == true)
        {
            audio.PlayOneShot(washingHands, washingHandsVolume);

            // Call StopOCDTimer from the OCDEffectManager script to stop the OCD effects.
            blur.StopOCDTimer();

            stopWashingHands = true;
        }
	}
}
