using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenDoor : MonoBehaviour {

    public float speed = 60f;

    private bool isOpen;
    private Quaternion closed;
    private Quaternion open;
    private Quaternion target;

    // Use this for initialization
    private void Start()
    {
        isOpen = false;
        closed = transform.rotation;
        open = Quaternion.AngleAxis(-90f, Vector3.right) * transform.rotation;
        target = closed;
    }

    private void Update()
    {
        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * speed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, Time.deltaTime * speed);
    }

    public void Activate()
    {

        if (isOpen)
        {
            target = closed;
        }
        else
        {
            target = open;
        }

        isOpen = !isOpen;
    }
}
