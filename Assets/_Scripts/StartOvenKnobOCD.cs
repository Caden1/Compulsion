using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOvenKnobOCD : MonoBehaviour 
{
	[HideInInspector]
	public bool isActivated; // Set to true when the OCD task is activated.

	public OvenKnobs ovenKnobsScript;

	private GameObject gameManagerObject;

	private void Start()
	{
		isActivated = false;

		gameManagerObject = GameObject.Find("GameManager");
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			if (isActivated == false)
			{
				isActivated = true; // To prevent the OCD task playing everytime I exit the collider.

				gameManagerObject.SendMessage("StartOCD", gameObject);

				StartCoroutine(OCDActiveLength());
			}
		}
	}

	public void CleanUp()
	{
		gameManagerObject.SendMessage("EndOCD", gameObject);

		StopCoroutine(OCDActiveLength());

		StartCoroutine(ResetTimer());
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
		while (true) 
		{
			yield return new WaitForSeconds (10);

			// Make the text above this one a decent size (knobs are a big one).
			// Start another coroutine here that calls an IEnumerable function that makes the 3D text pulse (Use a place-holder for now).
			// After this ten seconds, make it pulse faster. After 5 times running through, cap it.

			gameManagerObject.SendMessage("IncreaseInfluence", gameObject);
		}
	}
}
