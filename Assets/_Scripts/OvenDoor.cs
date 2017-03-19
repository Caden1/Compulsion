using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenDoor : MonoBehaviour {

    public float speed = 60f;

    private bool isOpen;
    private Quaternion closed;
    private Quaternion open;
    private Quaternion target;
    private Coroutine cor;

    // isOPen getter for Caden's CookCookies script.
    public bool IsOpen
    {
        get
        {
            return isOpen;
        }
    }

    // Use this for initialization
    private void Start()
    {
        isOpen = false;
        closed = transform.rotation;
        open = Quaternion.AngleAxis(90f, Vector3.forward) * transform.rotation;
        target = closed;
    }

    public void Activate()
    {
        if (cor != null)
            StopCoroutine(cor);

        if (isOpen)
            target = closed;
        else
            target = open;

        cor = StartCoroutine("Swing");
        isOpen = !isOpen;
    }

    private IEnumerator Swing()
    {
        Debug.Log(Quaternion.Angle(transform.rotation, target));
        while (Quaternion.Angle(transform.rotation, target) != 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, Time.deltaTime * speed);
            yield return null;
        }
    }
}
