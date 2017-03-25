using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVOnAndOff : MonoBehaviour
{
    public int numberOfTimesNeeded = 3; // Number needed to stop OCD

    private static int timesTurnedOnAndOff;
    private static bool isOn;

    // Use this for initialization
	void Start ()
    {
        timesTurnedOnAndOff = 0;

        isOn = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Activate()
    {
        if (isOn == false)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            timesTurnedOnAndOff++;
            isOn = true;
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            timesTurnedOnAndOff++;
            isOn = false;
        }

        if (timesTurnedOnAndOff == (numberOfTimesNeeded * 2))
        {
            timesTurnedOnAndOff = 0;
            //Debug.Log("Complete");

            // STOP OCD EFFECTS HERE (SEND MESSAGE BACK TO CAMERON TO STOP IT??)
        }
    }
}
