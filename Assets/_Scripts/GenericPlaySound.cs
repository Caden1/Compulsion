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
}
