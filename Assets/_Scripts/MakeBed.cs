using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBed : MonoBehaviour
{
    private BedroomTrigger bedroomTriggerScript;
	private GameObject normalBed;

    // Use this for initialization
    void Start ()
    {
        bedroomTriggerScript = GameObject.Find("BedroomTrigger").GetComponent<BedroomTrigger>();

		normalBed = GameObject.Find ("NormalBed");
    }
	
	public void Activate()
    {
        Destroy(gameObject);
        normalBed.GetComponent<GenericPlaySound>().PlaySoundRandomPitch(1f);
		normalBed.GetComponent<MeshRenderer> ().enabled = true;

        bedroomTriggerScript.CleanUp();
    }
}
