using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WashHands : MonoBehaviour
{
    private SinkKnob sinkKnobScript;
    private bool stopWashingHands;
    private OCDEffectManager blur;
    public AudioClip washingHands;
    public float washingHandsVolume = 0.5f;
    public AudioSource audio;
	private RandomWashHands randomWashHandsScript;
	private RigidbodyFirstPersonController rigidbodyFirstPersonControllerScript;

    // Use this for initialization
    void Start ()
    {
        GameObject sinkKnob = GameObject.Find("SinkKnob");
        sinkKnobScript = sinkKnob.GetComponent<SinkKnob>();
        stopWashingHands = false;
        //audio = GetComponent<AudioSource>();
		randomWashHandsScript = GameObject.Find("RandomWashHands").GetComponent<RandomWashHands>();
		rigidbodyFirstPersonControllerScript = GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		// randomWashHandsScript.Text.activeInHierarchy == true is making sure the OCD effect is active
		if (stopWashingHands == false && sinkKnobScript.IsOpen == true && randomWashHandsScript.Text == true)
        {
			rigidbodyFirstPersonControllerScript.enabled = false; // Disables movement
            audio.PlayOneShot(washingHands, washingHandsVolume);
            stopWashingHands = true;
			randomWashHandsScript.CleanUp();
			Invoke("EnableMovement", 4f);
        }
	}

	private void EnableMovement()
	{
		rigidbodyFirstPersonControllerScript.enabled = true; // Enables Movement
		stopWashingHands = false;
	}
}
