﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvenKnobs : MonoBehaviour
{
    private static Dictionary<string, bool> knobSet = new Dictionary<string, bool>();
	private StartOvenKnobOCD startOvenKnobOCDScript;

    public float speed = 200f;
	public static bool isStoveChecked = false;

    private bool isOn;
    private Quaternion on;
    private Quaternion off;
    private Quaternion target;
    private Coroutine cor;
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;
	public AudioClip clip4;
	private GameObject gameManagerObject;


    // Use this for initialization
    public void Start()
    {
        isOn = false;
        off = transform.rotation;
        on = Quaternion.AngleAxis(-135f, transform.up) * transform.rotation;
        target = off;

		startOvenKnobOCDScript = GameObject.Find("StartOvenKnobOCD").GetComponent<StartOvenKnobOCD>();
		gameManagerObject = GameObject.Find("GameManager");
    }

    public void Activate()
    {
        if (cor != null)
            StopCoroutine(cor);

        if (isOn)
            target = off;
        else
            target = on;

        cor = StartCoroutine("Swing");
        isOn = !isOn;

		if (startOvenKnobOCDScript.isActivated == true) 
		{
			if (knobSet.ContainsKey (gameObject.name)) 
			{
				knobSet [gameObject.name] = !knobSet [gameObject.name];

				if (!isOn) {
					int count = 0;

					foreach (bool b in knobSet.Values) {
						if (b == false)
							count++;
					}

					switch (count) {
					case 1: 
						gameManagerObject.SendMessage ("QueuePlayerSpeech", clip1);
						break;
					case 2:
						gameManagerObject.SendMessage ("QueuePlayerSpeech", clip2);
						break;
					case 3:
						gameManagerObject.SendMessage ("QueuePlayerSpeech", clip3);
						break;
					case 4:
						gameManagerObject.SendMessage ("QueuePlayerSpeech", clip4);
						break;
					}
				}
			} 
			else 
			{
				knobSet.Add (gameObject.name, isOn);
			}
			
			if (knobSet.Count == 4) 
			{
				bool complete = true;
				foreach (bool b in knobSet.Values) 
				{
					if (b == true)
						complete = false;
				}

				if (complete) 
				{
					isStoveChecked = true;
					knobSet.Clear (); // Clear the knob set so it doesn't continue to execute this statement

					startOvenKnobOCDScript.CleanUp(); // Clean up the OCD task. Function in the StartOvenKnobOCD script.
				}
			}
		}
    }
    

    private IEnumerator Swing()
    {
        //Debug.Log(Quaternion.Angle(transform.rotation, target));
        while (Quaternion.Angle(transform.rotation, target) != 0)
        {
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, Time.deltaTime * speed);
            yield return null;
        }
    }
}
