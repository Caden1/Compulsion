using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarRingingSound : MonoBehaviour
{

    private AudioSource source;
    public AudioClip earRinging;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayEarRinging(float vol)
    {
        source.volume = vol;
        source.clip = earRinging;
        source.Play();
    }
    public void StopEarRinging()
    {
        source.Stop();
        source.volume = 0.3f;
    }
}
