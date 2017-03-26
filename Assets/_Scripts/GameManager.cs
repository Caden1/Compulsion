using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] normalEvents;
    public GameObject[] ocdEvents;

    public AudioClip[] masterGameTimerAudioClips;

    private GameObject player;
    private AudioSource playerSoundSource;
    private Queue<AudioClip> queuedSounds;
    private bool isSoundPlaying;
    private float gameLength = 900f; //15 minutes to start adjust later
    private float startTime;

    private Dictionary<GameObject, OCD> ocds;
    private int totalInfluence;

    private void Start()
    {
        startTime = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        playerSoundSource = player.GetComponent<AudioSource>();
        queuedSounds = new Queue<AudioClip>();
        ocds = new Dictionary<GameObject, OCD>();
    }

    public void NormalEventCompleted()
    {
        
    }

    public void OCDEventCompleted()
    {

    }

    public void QueuePlayerSpeech(AudioClip clip)
    {
        queuedSounds.Enqueue(clip);
        if (!isSoundPlaying)
            StartCoroutine(PlaySounds());
    }

    private IEnumerator PlaySounds()
    {
        isSoundPlaying = true;
        while(queuedSounds.Count != 0)
        {
            AudioClip sound = queuedSounds.Dequeue();
            playerSoundSource.PlayOneShot(sound);
            yield return new WaitForSeconds(sound.length);
        }
        isSoundPlaying = false;

    }

    private IEnumerator MasterGameTimer()
    {
        int timeClipCounter = 0;
        while(Time.time - startTime < gameLength)
        {
            QueuePlayerSpeech(masterGameTimerAudioClips[timeClipCounter]);
            timeClipCounter++;
            yield return new WaitForSeconds(120f);

        }

        //GAME OVER (BAD ENDING)
    }
}
