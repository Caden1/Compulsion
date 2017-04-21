using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlushToilet : MonoBehaviour
{
    public float speed = 200f;

    private bool isFlushable;
    private Quaternion down;
    private Quaternion up;
    private Coroutine cor;
    private Coroutine cor2;

    private BathroomTrigger bathroomTriggerScript;

    // Use this for initialization
    private void Start()
    {
        isFlushable = true;
        down = Quaternion.AngleAxis(90f, transform.up) * transform.rotation;
        up = Quaternion.AngleAxis(0f, transform.up) * transform.rotation;

        bathroomTriggerScript = GameObject.Find("BathroomTrigger").GetComponent<BathroomTrigger>();
    }

    public void Activate()
    {
        if (isFlushable == true)
        {
            isFlushable = false; // Prevents interuption while flushing
            cor = StartCoroutine(Swing());
            Invoke("SwingBackInvoke", 0.5f);
        }
    }

    private IEnumerator Swing()
    {
        if(!isFlushable)
        {
            GetComponent<GenericPlaySound>().PlaySoundRandomPitch(.6f);
        }
        while (true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, down, Time.deltaTime * speed);

            yield return null;
        }
    }

    private void SwingBackInvoke()
    {
        StopCoroutine(cor);
        cor2 = StartCoroutine(SwingBack());
        Invoke("StopSwingBack", 0.75f);
    }

    private IEnumerator SwingBack()
    {
        while (true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, up, Time.deltaTime * speed);

            yield return null;
        }
    }

    private void StopSwingBack()
    {
        StopCoroutine(cor2);
        isFlushable = true;

        bathroomTriggerScript.CleanUp();
    }
}
