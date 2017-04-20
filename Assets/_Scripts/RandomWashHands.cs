using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWashHands : MonoBehaviour
{
	private GameObject gameManagerObject;
	private Coroutine cor;
	private Coroutine cor2;
	private FloatingText floatingtext;
	private bool textIsActive;
	public AudioClip clip;


	public bool Text
	{
		get
		{
			return textIsActive;
		}
	}

	private void Start()
	{
		gameManagerObject = GameObject.Find("GameManager");
		floatingtext = transform.Find("3DText").GetComponent<FloatingText>(); // Gets the child object called 3DText.
		textIsActive = false;
	}

	public void Activate()
	{
		Invoke("PlaySound", 15f);

		cor2 = StartCoroutine(OCDActiveLength());

		cor = StartCoroutine(StartOCDTextPulse());
	}

	public void CleanUp()
	{
        gameManagerObject.SendMessage("EndOCD", gameObject); // End it so it can execute again.

        StopCoroutine(cor2); // Stop the OCDActiveLength process

		floatingtext.Deactivate();
		textIsActive = false;

		StopCoroutine(cor); // Stop the StartOCDTextPulse process
	}

	private void PlaySound()
	{
		gameManagerObject.SendMessage("QueuePlayerSpeech", clip);
	}

	private IEnumerator OCDActiveLength()
	{
		while (true)
		{
			yield return new WaitForSeconds(10);

			floatingtext.Increase(); // The text pulse is in sync witht he IncreaseInfluence and therefore with the OCD effects.

			gameManagerObject.SendMessage("IncreaseInfluence", gameObject);
		}
	}

	private IEnumerator StartOCDTextPulse()
	{
		yield return new WaitForSeconds(16f); // Waits 16 seconds before initial start.
		floatingtext.Activate();
		textIsActive = true;
	}
}
