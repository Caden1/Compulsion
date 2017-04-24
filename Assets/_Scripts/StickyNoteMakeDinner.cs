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
	private GameObject plates;
	private GameObject forksandKnives;
	private GameObject cookies;
	private GameObject sandwhiches;
    private GameObject kitchenTableCollider;
    private KitchenTableCollider kitchenTableColliderScript;
    private Coroutine cor;
    private Coroutine cor2;

    private FloatingText floatingtext;
	private GameObject Everyday1text;

	public AudioClip clip;
	public Material red;

    // Use this for initialization
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        sponge = GameObject.Find("Sponge");
		cookies = GameObject.Find ("UncookedCookies");
		sandwhiches = GameObject.Find ("2SandwichesPickUp");
        kitchenTableCollider = GameObject.Find("KitchenTableCollider");
        kitchenTableColliderScript = GameObject.Find("KitchenTableCollider").GetComponent<KitchenTableCollider>();
		Everyday1text =  GameObject.Find("TempText"); // Gets the child object called 3DText.
		floatingtext = transform.Find("3DText").GetComponent<FloatingText>(); // Gets the child object called 3DText.
    }

    public void Activate()
    {
        // ADD SOUND EFFECT FOR RIPPING OFF STICKY NOTE
		/*
        // Disable sticky note, but do not destroy it. It's needed by the GameManager.
        */
		//gameObject.GetComponent<MeshRenderer>().enabled = false;


		gameObject.GetComponent<BoxCollider>().enabled = false;
		gameObject.GetComponent<MeshRenderer> ().material = red;
		Everyday1text.GetComponent<MeshRenderer> ().enabled = true;
        // Enable box colliders needed.

		if (ScrubTableWithSponge.scrubTable == false) {
			//Only enable the sponge collider if the table hasn't been scrubbed
			sponge.GetComponent<BoxCollider> ().enabled = true;
		}
		cookies.GetComponent<BoxCollider>().enabled = true;
		sandwhiches.GetComponent<BoxCollider>().enabled = true;
		kitchenTableColliderScript.MaybeDisableCollider(); // Decrements the static integer

		if (KitchenTableCollider.colliderEnabledCount == 0) // Only disable the box collider if no other task is using it.
		{
			kitchenTableCollider.GetComponent<BoxCollider>().enabled = false;
		}

        gameManagerObject.SendMessage("StartOCD", gameObject);
		Invoke("PlaySound", 4f);

        cor2 = StartCoroutine(OCDActiveLength());

        cor = StartCoroutine(StartOCDTextPulse());
    }

	private void PlaySound()
	{
		gameManagerObject.SendMessage("QueuePlayerSpeech", clip);
	}

    private IEnumerator OCDActiveLength()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);

            floatingtext.Increase(); // The text pulse is in sync witht he IncreaseInfluence and therefore with the OCD effects.

            gameManagerObject.SendMessage("IncreaseInfluence", gameObject);
        }
    }

    private IEnumerator StartOCDTextPulse()
    {
        yield return new WaitForSeconds(4.5f); // Waits 4 seconds before initial start.
        floatingtext.Activate();
    }


    public void CleanUp()
    {
        kitchenTableColliderScript.MaybeDisableCollider(); // Decrements the static integer

        if (KitchenTableCollider.colliderEnabledCount == 0) // Only disable the box collider if no other task is using it.
        {
            kitchenTableCollider.GetComponent<BoxCollider>().enabled = false;
        }

        gameManagerObject.SendMessage("EndOCD", gameObject);

        StopCoroutine(cor2); // Stop the OCDActiveLength process

        floatingtext.Deactivate();

        StopCoroutine(cor); // Stop the StartOCDTextPulse process
    }
    
}