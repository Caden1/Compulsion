using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObject : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Grab()
    {
        //Debug.Log("Hit");
        //gameObject.SetActive(false);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    public void SetDown()
    {
        //gameObject.SetActive(true);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
