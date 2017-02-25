using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObject : MonoBehaviour
{
    private static bool oneAtATime;
    private static bool twoPlates;
    private static bool forkAndKnife;

	// Use this for initialization
	void Start ()
    {
        oneAtATime = false;
        twoPlates = false;
        forkAndKnife = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Grab()
    {
        //Debug.Log("Hit");
        //gameObject.SetActive(false);
        //gameObject.GetComponent<MeshRenderer>().enabled = false;

        // FOR 2 PLATES:
        if (gameObject.name == "2PlatesPickup" && twoPlates == false)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
            //Debug.Log("Pickup Should be false: " + twoPlates);
            twoPlates = true;
            //Debug.Log("Pickup Should be true: " + twoPlates);
            oneAtATime = true;
        }
        else if (gameObject.name == "SetDownOnTable" && twoPlates == true)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            //Debug.Log("SetDown Should be true: " + twoPlates);
            twoPlates = false;
            //Debug.Log("SetDown Should be false: " + twoPlates);
            oneAtATime = false;
        }

        // FOR FORK AND KNIFE:
        else if (gameObject.name == "ForkKnifePickup" && forkAndKnife == false)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.GetChild(3).GetComponent<MeshRenderer>().enabled = false;
            forkAndKnife = true;
            oneAtATime = true;
        }
        else if (gameObject.name == "SetDownOnTable" && forkAndKnife == true)
        {
            // Specail cases becasue the children for fork and knife start at index 2
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(3).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(4).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(5).GetComponent<MeshRenderer>().enabled = true;
            forkAndKnife = false;
            oneAtATime = false;
        }
    }
}
