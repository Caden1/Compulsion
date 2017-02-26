using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenKnobs : MonoBehaviour
{
    public Blur blur;

    private Transform knob;
    private bool turning;
    private Vector3 origPos;
    private Quaternion origRot;

    private float knobXPos; // Becasue the only difference between the knobs is the x-position

    private static HashSet<string> knobSet = new HashSet<string>();

    // Use this for initialization
    void Start ()
    {
        knob = gameObject.transform;
        turning = false;
        origPos = knob.localPosition;
        origRot = knob.localRotation;

        
    }

    // Update is called once per frame
    void Update ()
    {
        if (turning == true)
        {
            // Use local position and rotation
            knob.localPosition = Vector3.Lerp(knob.localPosition, new Vector3(knobXPos, 0.0348f, -0.0286f), Time.deltaTime * 10.0f);
            knob.localRotation = Quaternion.Slerp(knob.localRotation, new Quaternion(-0.157f, -0.76f, 0.5f, 0.384f), Time.deltaTime * 10.0f);

            Invoke("TurnBack", 0.6f);
        }
        else
        {
            // Move back to orig pos
            knob.localPosition = Vector3.Lerp(knob.localPosition, new Vector3(origPos.x, origPos.y, origPos.z), Time.deltaTime * 10.0f);
            knob.localRotation = Quaternion.Slerp(knob.localRotation, new Quaternion(origRot.x, origRot.y, origRot.z, origRot.w), Time.deltaTime * 10.0f);
        }

        if (knobSet.Contains("pCylinder28") && knobSet.Contains("pCylinder29") && knobSet.Contains("pCylinder27") && knobSet.Contains("pCylinder26"))
        {
            // CALL FUNCTION FROM BLUR TO STOP THE OCD EFFECT HERE

            //Debug.Log("DONE!");
            knobSet.Clear(); // Clear the knob set so it doesn't continue to execute this statement
        }
    }

    private void TurnBack()
    {
        turning = false;
    }

    public void OCDTask()
    {
        turning = true;

        //blur.StopAndResetBlur();

        if (gameObject.name == "pCylinder28")
        {
            knobXPos = 0.0334f;
            knobSet.Add("pCylinder28");
        }
        else if (gameObject.name == "pCylinder29")
        {
            knobXPos = 0.03727f;
            knobSet.Add("pCylinder29");
        }
        else if (gameObject.name == "pCylinder27")
        {
            knobXPos = 0.04727f;
            knobSet.Add("pCylinder27");
        }
        else if (gameObject.name == "pCylinder26")
        {
            knobXPos = 0.05141f;
            knobSet.Add("pCylinder26");
        }
    }
}
