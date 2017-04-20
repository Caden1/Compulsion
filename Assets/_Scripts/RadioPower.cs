using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioPower : MonoBehaviour
{

    public float speed = 1f;
    public enum FaceDirection { POSX, NEGX, POSZ, NEGZ }
    public FaceDirection facing = FaceDirection.POSX;
    public AudioClip[] music;

    private bool isOn;
    private Vector3 off;
    private Vector3 on;
    private Vector3 target;
    private Coroutine cor;
    private Coroutine cor2;
    private GameObject gameManager;
    private AudioSource speaker;
    private int clipNumber;
    private bool oneTime;
    private GameObject stickyNote;


    // Use this for initialization
    private void Start()
    {
        isOn = false;
        oneTime = false;
        off = transform.position;
        stickyNote = GameObject.Find("RadioStickyNote");
        switch (facing)
        {
            case FaceDirection.POSX:
                on = transform.position + (Vector3.left * 0.015f);
                break;
            case FaceDirection.NEGX:
                on = transform.position + (Vector3.right * 0.015f);
                break;
            case FaceDirection.POSZ:
                on = transform.position + (Vector3.back * 0.015f);
                break;
            case FaceDirection.NEGZ:
                on = transform.position + (Vector3.forward * 0.015f);
                break;
        }
            
        gameManager = GameObject.Find("GameManager");
        speaker = GetComponent<AudioSource>();
        speaker.volume = 0;
        clipNumber = 0;
        speaker.clip = music[clipNumber++];
        speaker.Play();
    }

    public void Activate()
    {
        if (!oneTime)
            stickyNote.SendMessage("CleanUp");

        if (cor != null)
            StopCoroutine(cor);

        if (isOn)
        {
            speaker.volume = 0;
            transform.position = off;
        }
        else
        {
            speaker.volume = 1;
            transform.position = on;
        }

        isOn = !isOn;
    }

    public void ChangeStation()
    {
        if (isOn)
        {
            if (clipNumber >= music.Length)
            {
                clipNumber = 0;
            }

            speaker.Stop();
            speaker.clip = speaker.clip = music[clipNumber++];
            
            Invoke("RestartMusic", 0.1f);
        }      
    }

    public void RestartMusic()
    {
        speaker.Play();
    }
}
