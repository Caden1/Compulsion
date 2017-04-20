using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLightSwitch : MonoBehaviour
{

    private GameObject gameManagerObject;
    private Coroutine cor;
    private Coroutine cor2;
    private FloatingText floatingtext;
    public LightSwitch lightSwitchScript; // Assign by dragging a light switch into the Inpector
    public int numberOfTimesNeeded = 3; // Number needed to stop OCD
    private static int timesTurnedOnAndOff;
    private static bool randomIsOn;
	private bool textIsActive;
	private bool saidOne;
	private bool saidTwo;
	private bool saidThree;
	public AudioClip clip;
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;

    private void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        floatingtext = transform.Find("3DText").GetComponent<FloatingText>(); // Gets the child object called 3DText.
        randomIsOn = false;
		textIsActive = false;
		saidOne = false;
		saidTwo = false;
		saidThree = false;
    }

    private void Update()
    {
		if (textIsActive == true) 
		{
			if (lightSwitchScript.isOn == false && randomIsOn == false) 
			{
				timesTurnedOnAndOff++;
				randomIsOn = true;
			} 
			else if (lightSwitchScript.isOn == true && randomIsOn == true) 
			{
				timesTurnedOnAndOff++;
				randomIsOn = false;
			}

			switch (timesTurnedOnAndOff) 
			{
			case 2:
				if (saidOne == false) 
				{
					gameManagerObject.SendMessage ("QueuePlayerSpeech", clip1);
					saidOne = true;
				}
				break;
			case 4:
				if (saidTwo == false) 
				{
					gameManagerObject.SendMessage ("QueuePlayerSpeech", clip2);
					saidTwo = true;
				}
				break;
			case 6:
				if (saidThree == false) 
				{
					gameManagerObject.SendMessage ("QueuePlayerSpeech", clip3);
					saidThree = true;
				}
				break;
			}

			if (timesTurnedOnAndOff == (numberOfTimesNeeded * 2)) 
			{
				timesTurnedOnAndOff = 0;

				CleanUp ();
			}
		}
    }

    public void Activate()
    {
		Invoke("PlaySound", 15f);

        cor2 = StartCoroutine(OCDActiveLength());

        cor = StartCoroutine(StartOCDTextPulse());
    }

	private void PlaySound()
	{
		gameManagerObject.SendMessage("QueuePlayerSpeech", clip);
	}

    public void CleanUp()
    {
        gameManagerObject.SendMessage("EndOCD", gameObject); // End it so it can execute again.

        StopCoroutine(cor2); // Stop the OCDActiveLength process

        floatingtext.Deactivate();
		textIsActive = false;

        StopCoroutine(cor); // Stop the StartOCDTextPulse process

		saidOne = false;
		saidTwo = false;
		saidThree = false;
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
