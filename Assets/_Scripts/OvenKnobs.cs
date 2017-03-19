using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenKnobs : MonoBehaviour
{

    private static Dictionary<string, bool> knobSet = new Dictionary<string, bool>();

    public float speed = 200f;

    private bool isOn;
    private int knobCount = 4;
    private Quaternion on;
    private Quaternion off;
    private Quaternion target;
    private Coroutine cor;
    private OCDEffectManager blur;


    // Use this for initialization
    void Start ()
    {
        isOn = false;
        off = transform.rotation;
        on = Quaternion.AngleAxis(-135f, transform.up) * transform.rotation;
        target = off;
        blur = GameObject.Find("OCDEffectManager").GetComponent<OCDEffectManager>();
    }

    public void Activate()
    {
        if (cor != null)
            StopCoroutine(cor);

        if (isOn)
            target = off;
        else
            target = on;

        cor = StartCoroutine("Swing");
        isOn = !isOn;

        if (knobSet.ContainsKey(gameObject.name))
            knobSet[gameObject.name] = !knobSet[gameObject.name];
        else
            knobSet.Add(gameObject.name, true);

        if (knobSet.Count == knobCount)
        {
            bool complete = true;
            foreach (bool b in knobSet.Values)
            {
                if (b == true)
                    complete = false;
            }

            if (complete)
            {
                knobSet.Clear(); // Clear the knob set so it doesn't continue to execute this statement
                blur.StopOCDTimer();
            }
        }
    }

    private IEnumerator Swing()
    {
        //Debug.Log(Quaternion.Angle(transform.rotation, target));
        while (Quaternion.Angle(transform.rotation, target) != 0)
        {
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, Time.deltaTime * speed);
            yield return null;
        }
    }
}
