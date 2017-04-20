using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioKnob : MonoBehaviour {

    public float speed = 90f;
    public RadioPower radio;

    private Quaternion target;
    private Coroutine cor;
    private Vector3 dir;
    private float angle;

    // Use this for initialization
    public void Start()
    {
        switch (radio.facing)
        {
            case RadioPower.FaceDirection.POSX:
                angle = 30;
                dir = Vector3.right;
                break;
            case RadioPower.FaceDirection.NEGX:
                angle = 30;
                dir = Vector3.left;
                break;
            case RadioPower.FaceDirection.POSZ:
                angle = 30;
                dir = Vector3.forward;
                break;
            case RadioPower.FaceDirection.NEGZ:
                angle = 30;
                dir = Vector3.back;
                break;
        }

        target = Quaternion.AngleAxis(angle, dir) * transform.rotation;
    }

    public void Activate()
    {
        if (cor != null)
            StopCoroutine(cor);

        radio.ChangeStation();
        target = Quaternion.AngleAxis(angle, dir) * target;
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
