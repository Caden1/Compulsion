using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will start the Make Dinner everyday task.
/// It will also start the OCD tasks for scrubbing the table and washing hands.
/// </summary>
public class StickyNoteMakeDinner : MonoBehaviour
{
    private GameObject gameManagerObject;
    private GameObject sponge;
    private GameObject kitchenTableCollider;
    private KitchenTableCollider kitchenTableColliderScript;

    // Use this for initialization
    void Start ()
    {
        gameManagerObject = GameObject.Find("GameManager");
        sponge = GameObject.Find("Sponge");
        kitchenTableCollider = GameObject.Find("KitchenTableCollider");
        kitchenTableColliderScript = GameObject.Find("KitchenTableCollider").GetComponent<KitchenTableCollider>();
    }
	
    public void Activate()
    {
        // ADD SOUND EFFECT FOR RIPPING OFF STICKY NOTE
        // Disable sticky note, but do not destroy it. It's needed by the GameManager.
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

        // Enable box colliders needed.
        sponge.GetComponent<BoxCollider>().enabled = true;


        // Set a boolean to make sure turning on the faucet will activate washing hands


        gameManagerObject.SendMessage("StartOCD", gameObject);

        StartCoroutine(OCDActiveLength()); // Start the OCDActiveLength process
    }

    private IEnumerator OCDActiveLength()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);

            // Make the text above this one a decent size (knobs are a big one).
            // Start another coroutine here that calls an IEnumerable function that makes the 3D text pulse (Use a place-holder for now).
            // After this ten seconds, make it pulse faster. After 5 times running through, cap it.

            gameManagerObject.SendMessage("IncreaseInfluence", gameObject);
        }
    }

    public void CleanUp()
    {
        kitchenTableColliderScript.MaybeDisableCollider(); // Decrements the static integer

        if (KitchenTableCollider.colliderEnabledCount == 0) // Only disable the box collider if no other task is using it.
        {
            kitchenTableCollider.GetComponent<BoxCollider>().enabled = false;
        }

        gameManagerObject.SendMessage("EndOCD", gameObject);

        StopCoroutine(OCDActiveLength()); // Stop the OCDActiveLength process
    }
}
