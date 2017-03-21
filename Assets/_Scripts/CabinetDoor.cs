using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetDoor : MonoBehaviour {

    public float speed = 60f;
    public bool swingClockwise;

    private bool isOpen;
    private Transform parent;
    private Quaternion closed;
    private Quaternion open;
    private Quaternion target;
    private Coroutine cor;

    // Use this for initialization
    private void Start()
    {
        isOpen = false;
        parent = transform.parent;
        closed = parent.rotation;
        if(swingClockwise)
            open = Quaternion.AngleAxis(80f, Vector3.up) * parent.rotation;
        else
            open = Quaternion.AngleAxis(-80f, Vector3.up) * parent.rotation;

        target = closed;
    }

    public void Activate()
    {
        if(cor != null)
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
        while(Quaternion.Angle(transform.rotation, target) != 0)
        {
            parent.rotation = Quaternion.RotateTowards(transform.rotation, target, Time.deltaTime * speed);
            yield return null;
        }
    }
}
