using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVSwitch : MonoBehaviour {

    private bool isOn;
    private MovieTexture tv;
    private MeshRenderer render;
    private AudioSource audio;
    private Transform player;
    private RaycastHit hit;

    public LayerMask mask;

    private Collider livingRoomTrigger;

    private void Start()
    {
        tv = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);
        audio = GetComponent<AudioSource>();
        //audio.clip = tv.audioClip;
        render = GetComponent<MeshRenderer>();
        tv.loop = true;
        player = GameObject.Find("Player").transform;

        livingRoomTrigger = GameObject.Find("LivingRoomTrigger").GetComponent<Collider>();
        livingRoomTrigger.enabled = false;
    }

    private void Update()
    {
        if (isOn)
        {
            if(Physics.Linecast(transform.position, player.position, out hit, mask))
            {
                if(hit.transform.tag == "Wall")
                {
                    audio.volume = 0.1f;
                    Debug.Log("Rawr");
                }
                else
                {
                    audio.volume = 1f;
                    Debug.Log("BOO");
                }
            }
        }
    }

    public void Activate()
    {
        if (isOn)
        {
            livingRoomTrigger.enabled = false;

            tv.Stop();
            audio.Stop();
            render.enabled = false;
        }
        else
        {
            livingRoomTrigger.enabled = true;

            render.enabled = true;
            tv.Play();
            audio.Play();
        }

        isOn = !isOn;
    }

    public bool IsTVPlaying()
    {
        return isOn;
    }
}
