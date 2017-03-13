using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObject : MonoBehaviour
{
    private static bool oneAtATime;
    //private static bool twoPlates;
    //private static bool forkAndKnife;
    private static bool sponge;

    private bool scrubTable;
    private bool scrubLeftDir;

    public Transform spongePosition; 

    // Use this for initialization
    void Start ()
    {
        oneAtATime = false; // not being used yet
        //twoPlates = false;
        //forkAndKnife = false;
        sponge = false;

        scrubTable = false;
        scrubLeftDir = true;

        //spongePosition = GameObject.FindGameObjectWithTag("SpongeForScrubbing").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (scrubTable == true)
        {
            //Invoke("ReverseScrubDirection", 0.25f);

            if (scrubLeftDir == true)
            {
                spongePosition.position = Vector3.Lerp(spongePosition.position,
                    new Vector3(spongePosition.position.x + 0.8f, spongePosition.position.y, spongePosition.position.z - 1.5f), Time.deltaTime * 2.0f);

                Invoke("ReverseScrubDirection", 0.25f);
            }
            else
            {
                spongePosition.position = Vector3.Lerp(spongePosition.position,
                    new Vector3(spongePosition.position.x - 0.8f, spongePosition.position.y, spongePosition.position.z + 1.5f), Time.deltaTime * 2.0f);

                //Invoke("ReverseScrubDirection", 0.15f);
            }

            

            Invoke("StopScrubbing", 2.0f);
            //gameObject.transform.GetChild(6).GetComponent<MeshRenderer>().enabled = true;
        }
	}

    private void ReverseScrubDirection()
    {
        scrubLeftDir = false;

        Invoke("ReverseScrubDirection2", 0.25f);
    }

    private void ReverseScrubDirection2()
    {
        scrubLeftDir = true;
    }

    private void StopScrubbing()
    {
        scrubTable = false;
        spongePosition.GetComponent<MeshRenderer>().enabled = false;
    }

    public void Grab()
    {
        //Debug.Log("Hit");
        //gameObject.SetActive(false);
        //gameObject.GetComponent<MeshRenderer>().enabled = false;

        // FOR 2 PLATES:
        /*
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
        */

        // FOR FORK AND KNIFE:
        /*else*/ /* if (gameObject.name == "ForkKnifePickup" && forkAndKnife == false)
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
        */

        // FOR SPONGE:
        /*else*/ if(gameObject.name == "Sponge" && sponge == false)
        {
            gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
            sponge = true;
        }
        else if (gameObject.name == "SetDownOnTable" && sponge == true)
        {
            gameObject.transform.GetChild(6).GetComponent<MeshRenderer>().enabled = true;
            sponge = false;
            scrubTable = true;
        }
    }
}
