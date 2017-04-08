using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBed : MonoBehaviour
{
    private BedroomTrigger bedroomTriggerScript;

    // Use this for initialization
    void Start ()
    {
        bedroomTriggerScript = GameObject.Find("BedroomTrigger").GetComponent<BedroomTrigger>();
    }
	
	public void Activate()
    {
        Destroy(gameObject);

        bedroomTriggerScript.CleanUp();
    }
}
