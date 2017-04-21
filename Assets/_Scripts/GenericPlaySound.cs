using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericPlaySound : MonoBehaviour {

    public AudioSource source;
    public AudioClip[] clip;

	// Use this for initialization
	void Start ()
    {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlaySoundRandomPitch(float volume = .7f)
    {
        source.pitch = Random.Range(.9f, 1.1f);
        source.PlayOneShot(clip[Random.Range(0, clip.Length)], volume);
    }

    public void PlayGivenSoundRandomPitch(int i, float volume = .7f)
    {
        source.pitch = Random.Range(.9f, 1.1f);
        source.PlayOneShot(clip[i], volume);
    }
    public void PlaySoundLoop(float volume = .7f)
    {
        source.loop = true;
        source.clip = clip[0];
        source.volume = volume;
        source.Play();
    }
    public void StopSoundLoop()
    {
        source.Stop();
    }
}
