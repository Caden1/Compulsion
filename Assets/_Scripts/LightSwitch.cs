using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

    public Light[] lights;
    public bool startOn;

    private Transform lever;
    private Quaternion on;
    private Quaternion off;

    private void Start()
    {
        lever = GetComponentInChildren<Transform>();
        if (startOn)
        {
            on = lever.rotation;

            if (Vector3.forward == lever.forward)
                off = Quaternion.Euler(lever.rotation.eulerAngles +  Vector3.right * 90f);
            else
                off = Quaternion.Euler(lever.rotation.eulerAngles + Vector3.forward * 90f);
        }
        else
        {
            off = lever.rotation;

            if (Vector3.forward != lever.forward)
                on = Quaternion.Euler(lever.rotation.eulerAngles + Vector3.right * -90f);
            else
                on = Quaternion.Euler(lever.rotation.eulerAngles + Vector3.forward * -90f);
        }
    }




    // Use this for initialization


}
