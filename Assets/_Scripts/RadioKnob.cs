using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioKnob : MonoBehaviour {

    public float speed = 30f;
    public RadioPower radio;

    private Quaternion old;
    private Quaternion target;
    private Coroutine cor;

    // Use this for initialization
    public void Start()
    {
        target = Quaternion.AngleAxis(-30f, Vector3.forward) * transform.rotation;
    }

    public void Activate()
    {
        if (cor != null)
            StopCoroutine(cor);

        radio.ChangeStation();
        target = Quaternion.AngleAxis(-30f, Vector3.forward) * target; ;
        cor = StartCoroutine("Swing");
    }

    public IEnumerator Swing()
    {
        while (Quaternion.Angle(transform.rotation, target) != 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, Time.deltaTime * speed);
            yield return null;
        }
    }
}
