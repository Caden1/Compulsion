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
    private GameObject gameManagerObject;
    private GameManager gameManagerScript;
    private Coroutine cor;
    private Coroutine cor2;

    private FloatingText floatingtext;

    public AudioClip clip;


    private void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        floatingtext = transform.Find("3DText").GetComponent<FloatingText>(); // Gets the child object called 3DText.
    }

    private void PlaySound()
    {
        gameManagerObject.SendMessage("QueuePlayerSpeech", clip);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Reset the TV counter to zero
            TVOnAndOff.timesTurnedOnAndOff = 0;

            gameManagerObject.SendMessage("StartOCD", gameObject);
            Invoke("PlaySound", 0.5f);

            cor2 = StartCoroutine(OCDActiveLength()); // Start the OCDActiveLength process

            cor = StartCoroutine(StartOCDTextPulse());
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
        yield return null;
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
