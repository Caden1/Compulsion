﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOvenKnobOCD : MonoBehaviour 
{
	[HideInInspector]
	public bool isActivated; // Set to true when the OCD task is activated.
	public OvenKnobs ovenKnobsScript; // Drag one of the oven knobs into the Untiy Inspector for this.
	private GameObject gameManagerObject;
	private GameManager gameManagerScript;
	private Coroutine cor;
	private Coroutine cor2;
	private FloatingText floatingtext;
	public AudioClip clip;
	private bool textIsActive;


	public bool Text
	{
		get
		{
			return textIsActive;
		}
	}

	private void Start()
	{
		isActivated = false;
		gameManagerObject = GameObject.Find("GameManager");
		gameManagerScript = GameObject.Find ("GameManager").GetComponent<GameManager>();
		floatingtext = transform.Find("3DText").GetComponent<FloatingText>(); // Gets the child object called 3DText.
		textIsActive = false;
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			if (isActivated == false)
			{
				isActivated = true; // To prevent the OCD task playing everytime I exit the collider.

				gameManagerObject.SendMessage("StartOCD", gameObject);
				Invoke("PlaySound", 1f);

				cor2 = StartCoroutine(OCDActiveLength()); // Start the OCDActiveLength process

				cor = StartCoroutine(StartOCDTextPulse());
			}
		}
	}

	private void PlaySound()
	{
		gameManagerObject.SendMessage("QueuePlayerSpeech", clip);
	}

	/// <summary>
	/// Allows this OCD effect to be triggered again.
	/// </summary>
	private IEnumerator ResetTimer()
	{
		yield return new WaitForSeconds(60f);

        isActivated = false;
	}

	private IEnumerator OCDActiveLength()
	{
		while (true) // While the coroutine is active, this loop will continue to execute.
		{
			yield return new WaitForSeconds (10);

			floatingtext.Increase(); // The text pulse is in sync witht he IncreaseInfluence and therefore with the OCD effects.

			gameManagerObject.SendMessage("IncreaseInfluence", gameObject);
		}
	}

	private IEnumerator StartOCDTextPulse()
	{
		yield return new WaitForSeconds(2f); // Waits 10 seconds before initial start.
		floatingtext.Activate();
		textIsActive = true;
	}

	public void CleanUp()
	{
		gameManagerObject.SendMessage("EndOCD", gameObject);

		StopCoroutine(cor2); // Stop the OCDActiveLength process

		StartCoroutine(ResetTimer());

		floatingtext.Deactivate();
		textIsActive = false;

		StopCoroutine(cor); // Stop the StartOCDTextPulse process
	}
}
