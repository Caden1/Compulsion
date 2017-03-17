using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkKnob : MonoBehaviour {

    public float speed = 90f;

    private bool isOpen;
    private Quaternion closed;
    private Quaternion open;
    private Quaternion target;
    private Coroutine cor;
    private ParticleSystem water;

    // Use this for initialization
    private void Start()
    {
        isOpen = false;
        water = GameObject.Find("WaterParticleEffect").GetComponent<ParticleSystem>();
        water.Stop();
        closed = transform.rotation;
        open = Quaternion.AngleAxis(-180f, Vector3.right) * transform.rotation;
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

        if (isOpen)
            water.Play();
        else
            water.Stop();
    }
}
