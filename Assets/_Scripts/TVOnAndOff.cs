using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVOnAndOff : MonoBehaviour
{
    public int numberOfTimesNeeded = 3; // Number needed to stop OCD

    public static int timesTurnedOnAndOff;
    private static bool isOn;
    private LivingRoomTrigger livingRoomTriggerScript;
	private GameObject gameManagerObject;
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;

    // Use this for initialization
    void Start ()
    {
        timesTurnedOnAndOff = 0;
        isOn = false;
        livingRoomTriggerScript = GameObject.Find("LivingRoomTrigger").GetComponent<LivingRoomTrigger>();
		gameManagerObject = GameObject.Find("GameManager");
    }

    public void Activate()
    {
		if (livingRoomTriggerScript.Text == true) 
		{
			if (isOn == false) 
			{
				// Turn TV on here. Use Cameron's Shooting Stars vid
				//gameObject.transform.GetChild(0).gameObject.SetActive(true);
				timesTurnedOnAndOff++;
				isOn = true;
			} 
			else 
			{
				// Turn TV off here. Use Cameron's Shooting Stars vid
				//gameObject.transform.GetChild(0).gameObject.SetActive(false);
				timesTurnedOnAndOff++;
				isOn = false;
			}

			switch (timesTurnedOnAndOff) 
			{
			case 2:
				gameManagerObject.SendMessage ("QueuePlayerSpeech", clip1);
				break;
			case 4:
				gameManagerObject.SendMessage ("QueuePlayerSpeech", clip2);
				break;
			case 6:
				gameManagerObject.SendMessage ("QueuePlayerSpeech", clip3);
				break;
			}

			if (timesTurnedOnAndOff == (numberOfTimesNeeded * 2)) 
			{
				timesTurnedOnAndOff = 0;
				//Debug.Log("Complete");

				livingRoomTriggerScript.CleanUp ();
			}
		}
    }
}
