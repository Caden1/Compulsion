using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomTrigger : MonoBehaviour
{
    [HideInInspector]
    public bool isActivated; // Set to true when the OCD task is activated.
    private GameObject gameManagerObject;
    private GameManager gameManagerScript;
    private Coroutine cor;
    private Coroutine cor2;
    private BoxCollider wrinkledSheets;

    private FloatingText floatingtext;


    private void Start()
    {
        isActivated = false;
        gameManagerObject = GameObject.Find("GameManager");
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        floatingtext = transform.Find("3DText").GetComponent<FloatingText>(); // Gets the child object called 3DText.
        wrinkledSheets = GameObject.Find("WrinkledSheets").GetComponent<BoxCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isActivated == false)
            {
                //Debug.Log("Player in Bedroom!");

                wrinkledSheets.enabled = true;

                isActivated = true; // To prevent the OCD task playing everytime I enter the collider.

                gameManagerObject.SendMessage("StartOCD", gameObject);

                cor2 = StartCoroutine(OCDActiveLength()); // Start the OCDActiveLength process

                cor = StartCoroutine(StartOCDTextPulse());
            }
        }
    }

    private IEnumerator OCDActiveLength()
    {
        while (true) // While the coroutine is active, this loop will continue to execute.
        {
            yield return new WaitForSeconds(10);

            floatingtext.Increase(); // The text pulse is in sync witht he IncreaseInfluence and therefore with the OCD effects.

            gameManagerObject.SendMessage("IncreaseInfluence", gameObject);
        }
    }

    private IEnumerator StartOCDTextPulse()
    {
        yield return new WaitForSeconds(2f); // Waits 10 seconds before initial start. Match this with starting IncreaseInfluence
        floatingtext.Activate();
    }

    public void CleanUp()
    {
        gameManagerObject.SendMessage("EndOCD", gameObject);

        StopCoroutine(cor2); // Stop the OCDActiveLength process

        floatingtext.Deactivate();

        StopCoroutine(cor); // Stop the StartOCDTextPulse process
    }
}
