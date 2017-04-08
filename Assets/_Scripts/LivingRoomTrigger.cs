using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Can be used for triggering events in the living room.
/// So far it does:
///     TV on/off OCD task.
/// </summary>
public class LivingRoomTrigger : MonoBehaviour
{
    [HideInInspector]
    public bool isActivated; // Set to true when the OCD task is activated.
    private GameObject gameManagerObject;
    private GameManager gameManagerScript;
    private Coroutine cor;
    private Coroutine cor2;

    private FloatingText floatingtext;


    private void Start()
    {
        isActivated = false;
        gameManagerObject = GameObject.Find("GameManager");
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        floatingtext = transform.Find("3DText").GetComponent<FloatingText>(); // Gets the child object called 3DText.
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isActivated == false)
            {
                isActivated = true; // To prevent the OCD task playing everytime I exit the collider.

                gameManagerObject.SendMessage("StartOCD", gameObject);

                cor2 = StartCoroutine(OCDActiveLength()); // Start the OCDActiveLength process

                cor = StartCoroutine(StartOCDTextPulse());
            }
        }
    }

    /// <summary>
    /// Allows this OCD effect to be triggered again.
    /// </summary>
    private IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(60f);

        isActivated = false;
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
        yield return new WaitForSeconds(10f); // Waits 10 seconds before initial start. Match this with starting IncreaseInfluence
        floatingtext.Activate();
    }

    public void CleanUp()
    {
        gameManagerObject.SendMessage("EndOCD", gameObject);

        StopCoroutine(cor2); // Stop the OCDActiveLength process

        StartCoroutine(ResetTimer());

        floatingtext.Deactivate();

        StopCoroutine(cor); // Stop the StartOCDTextPulse process
    }
}
