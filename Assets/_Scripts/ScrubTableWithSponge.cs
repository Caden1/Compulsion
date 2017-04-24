using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ScrubTableWithSponge : MonoBehaviour
{
    public OCDEffectManager blur;

    private StickyNoteMakeDinner stickyNoteMakeDinnerScript;
    private static bool sponge;
    private Transform spongePosition;
	public static bool scrubTable;
    private bool scrubLeftDir;
    private GameObject spongeReference;
    private Transform spongeReferencePosition;
    private GameObject newSpongeAfterScrubbing;
    private KitchenTableCollider kitchenTableColliderScript;
	private RigidbodyFirstPersonController rigidbodyFirstPersonControllerScript;

    // Use this for initialization
    void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("OCDManager");
        blur = g.GetComponent<OCDEffectManager>();
        spongePosition = GameObject.Find("KitchenTableCollider").transform.GetChild(6); // Gets the transform of the sponge on the table.
        sponge = false;
        scrubTable = false;
        scrubLeftDir = true;
        spongeReference = GameObject.Find("Sponge"); // Need a reference to the sponge.
        newSpongeAfterScrubbing = GameObject.Find("NewSponge");
        stickyNoteMakeDinnerScript = GameObject.Find("StickyNoteMakeDinner").GetComponent<StickyNoteMakeDinner>();
        kitchenTableColliderScript = GameObject.Find("KitchenTableCollider").GetComponent<KitchenTableCollider>();
		rigidbodyFirstPersonControllerScript = GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scrubTable == true)
        {
			rigidbodyFirstPersonControllerScript.enabled = false; // Disable movement

            if (scrubLeftDir == true)
            {
                spongePosition.position = Vector3.Lerp(spongePosition.position,
                    new Vector3(spongePosition.position.x + 0.8f, spongePosition.position.y, spongePosition.position.z - 1.5f), Time.deltaTime * 2.0f);
                spongePosition.GetComponent<GenericPlaySound>().PlaySoundRandomPitch(.1f); // Play scrub noise

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
		rigidbodyFirstPersonControllerScript.enabled = true; // Can move agian
        spongePosition.GetComponent<MeshRenderer>().enabled = false;
		newSpongeAfterScrubbing.transform.GetComponent<MeshRenderer>().enabled = false;

        stickyNoteMakeDinnerScript.CleanUp();
    }

    public void Scrub()
    {
        kitchenTableColliderScript.EnableCollider(); // Increments the static integer and enables the collider.

        if (gameObject.name == "Sponge" && sponge == false)
        {
            SendMessage("PickUpAndHold", gameObject, SendMessageOptions.DontRequireReceiver);
        }
        else if (gameObject.name == "KitchenTableCollider" && sponge == true)
        {
            SendMessage("SetDown", SendMessageOptions.DontRequireReceiver);
            //Debug.Log ("Table has been scrubbed");
			Destroy(spongeReference);
            spongeReference.transform.GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.GetChild(6).GetComponent<MeshRenderer>().enabled = true;
            sponge = false;
            scrubTable = true;
			//Debug.Log ("Scrub Table task bool: " + scrubTable);
        }
        
        else if (gameObject.name == "SpongeCollider" && scrubTable == false) // To put the sponge back by the sink
        {
            SendMessage("SetDown", SendMessageOptions.DontRequireReceiver);
            Destroy(spongeReference);
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        }
        
    }

    public void SetVarTrue()
    {
        sponge = true;
    }
}