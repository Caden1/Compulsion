using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrubTableWithSponge : MonoBehaviour
{
    private static bool sponge;

    private Transform spongePosition;
    private bool scrubTable;
    private bool scrubLeftDir;

    // Use this for initialization
    void Start ()
    {
        spongePosition = GameObject.Find("KitchenTableCollider").transform.GetChild(6); // Gets the transform of the sponge on the table.
        sponge = false;
        scrubTable = false;
        scrubLeftDir = true;
    }

    // Update is called once per frame
    void Update()
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

    public void Scrub()
    {
        if (gameObject.name == "Sponge" && sponge == false)
        {
            gameObject.transform.GetComponent<MeshRenderer>().enabled = false;
            sponge = true;
        }
        else if (gameObject.name == "KitchenTableCollider" && sponge == true)
        {
            gameObject.transform.GetChild(6).GetComponent<MeshRenderer>().enabled = true;
            sponge = false;
            scrubTable = true;
        }
    }
}
