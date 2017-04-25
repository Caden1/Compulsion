using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartOfGameScript : MonoBehaviour {

    public AudioClip clip;
    public AudioClip winClip;
    public AudioClip loseClip;
    public float SecondsToPlaySound;
    private CameraFadeInOut fade;

    private GameManager speaker;
    private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController player;

	// Use this for initialization
	private void Start () {
        speaker = GameObject.Find("GameManager").GetComponent<GameManager>();
        Invoke("PlayClip", SecondsToPlaySound);
        player = GameObject.Find("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
        fade = GameObject.Find("FadePane").GetComponent<CameraFadeInOut>();
	}
	
    private void PlayClip()
    {
        Invoke("ActivatePlayerMovement", clip.length-1f);  // Add Blackness
        speaker.QueuePlayerSpeech(clip);
    }

    private void ActivatePlayerMovement()
    {
        StartCoroutine(fade.FadeIn());
        player.enabled = true;
    }

    public void EndGame(bool win)
    {
        player.enabled = false;
        StartCoroutine(fade.FadeOut());
        if (win)
            Invoke("WinSound", 2f);
        else
            Invoke("LoseSound", 2f);
    }

    private void WinSound()
    {
        speaker.QueuePlayerSpeech(winClip);
        Invoke("GoBackToMenu", winClip.length);
    }

    private void LoseSound()
    {
        speaker.QueuePlayerSpeech(loseClip);
        Invoke("GoBackToMenu", loseClip.length);
    }

    private void GoBackToMenu()
    {
        SceneManager.LoadScene("PinakScene");
    }
}
