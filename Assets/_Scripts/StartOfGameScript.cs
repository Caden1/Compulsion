using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartOfGameScript : MonoBehaviour {

    public AudioClip clip;
    public float SecondsToPlaySound;
    public float SecondsToLockPlayer;

    private GameManager speaker;
    private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController player;

	// Use this for initialization
	private void Start () {
        speaker = GameObject.Find("GameManager").GetComponent<GameManager>();
        Invoke("PlayClip", SecondsToPlaySound);
        player = GameObject.Find("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
	}
	
    private void PlayClip()
    {
        Invoke("ActivatePlayerMovement", SecondsToLockPlayer);  // Add Blackness
        speaker.QueuePlayerSpeech(clip);
    }

    private void ActivatePlayerMovement()
    {
        player.enabled = true;
    }
}
