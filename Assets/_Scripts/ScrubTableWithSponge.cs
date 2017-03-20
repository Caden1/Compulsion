using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrubTableWithSponge : MonoBehaviour
{
	public OCDEffectManager blur;

    private static bool sponge;
    private Transform spongePosition;
    private bool scrubTable;
    private bool scrubLeftDir;
    private GameObject spongeReference;

    // Use this for initialization
    void Start ()
    {
		GameObject g = GameObject.FindGameObjectWithTag ("OCDManager");
		blur = g.GetComponent<OCDEffectManager> ();

        spongePosition = GameObject.Find("KitchenTableCollider").transform.GetChild(6); // Gets the transform of the sponge on the table.
        sponge = false;
        scrubTable = false;
        scrubLeftDir = true;

        spongeReference = GameObject.Find("Sponge"); // Need a reference to the sponge.
    }

    // Update is called once per frame
    void Update()
    {
        if (scrubTable == true)
        {
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
            }

            Invoke("StopScrubbing", 2.0f);
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

        // Call StopOCDTimer from the OCDEffectManager script to stop the OCD effects.
        blur.StopOCDTimer();
    }

    public void Scrub()
    {
        if (gameObject.name == "Sponge" && sponge == false)
        {
            SendMessage("PickUpAndHold", gameObject, SendMessageOptions.DontRequireReceiver);
        }
        else if (gameObject.name == "KitchenTableCollider" && sponge == true)
        {
            SendMessage("SetDown", SendMessageOptions.DontRequireReceiver);
			//Debug.Log ("Table has been scrubbed");
            Destroy(spongeReference);
            gameObject.transform.GetChild(6).GetComponent<MeshRenderer>().enabled = true;
            sponge = false;
            scrubTable = true;
			GameObject.Find("2PlatesPickup").GetComponent<BoxCollider>().enabled = true;
			GameObject.FindGameObjectWithTag ("SetTable").GetComponent<Text> ().enabled = false;
			GameObject.FindGameObjectWithTag ("OCDScrub").GetComponent<Text> ().text = "Set the Table";
        }
    }

    public void SetVarTrue()
    {
        sponge = true;
    }
}
