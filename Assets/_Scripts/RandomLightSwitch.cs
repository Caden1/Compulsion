using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLightSwitch : MonoBehaviour
{

    private GameObject gameManagerObject;
    private Coroutine cor;
    private Coroutine cor2;
    private FloatingText floatingtext;

    public LightSwitch lightSwitchScript; // Assign by dragging a light switch into the Inpector
    public int numberOfTimesNeeded = 3; // Number needed to stop OCD

    private static int timesTurnedOnAndOff;
    private static bool randomIsOn;

    private void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        floatingtext = transform.Find("3DText").GetComponent<FloatingText>(); // Gets the child object called 3DText.
        randomIsOn = false;
    }

    private void Update()
    {
        if (lightSwitchScript.isOn == false && randomIsOn == false)
        {
            timesTurnedOnAndOff++;
            randomIsOn = true;
        }
        else if (lightSwitchScript.isOn == true && randomIsOn == true)
        {
            timesTurnedOnAndOff++;
            randomIsOn = false;
        }

        if (timesTurnedOnAndOff == (numberOfTimesNeeded * 2))
        {
            timesTurnedOnAndOff = 0;

            CleanUp();
        }
    }

    public void Activate()
    {
        Debug.Log("Random Light Switch Activated!");

        cor2 = StartCoroutine(OCDActiveLength());

        cor = StartCoroutine(StartOCDTextPulse());
    }

    public void CleanUp()
    {
        gameManagerObject.SendMessage("EndOCD", gameObject); // End it so it can execute again.

        StopCoroutine(cor2); // Stop the OCDActiveLength process

        floatingtext.Deactivate();

        StopCoroutine(cor); // Stop the StartOCDTextPulse process
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
        yield return new WaitForSeconds(10f); // Waits 10 seconds before initial start. Match this with starting IncreaseInfluence
        floatingtext.Activate();
    }
}
