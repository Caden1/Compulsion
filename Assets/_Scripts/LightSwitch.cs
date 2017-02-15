using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

    public Light[] lights;
    public bool isOn;
    public Transform lever;

    public void Activate()
    {
        if (isOn)
            lever.Rotate(Vector3.up * -20f);
        else
            lever.Rotate(Vector3.up * 20f);
        

        isOn = !isOn;
        foreach (Light light in lights)
        {
            light.enabled = !light.enabled;
        }
    }
}
