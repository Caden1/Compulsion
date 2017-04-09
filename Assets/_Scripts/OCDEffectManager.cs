using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OCDEffectManager : MonoBehaviour
{

    public GameObject playerCamera;
    public GameObject playerAudio;
    public GameObject earRingingAudio;
    //public bool performOCDEffects = false;
    private float timeSinceLastOCDAttack = 0;
    // private float timeUntilIncreasedEffects = 60;
    private bool activeAttack = false;
    private float timeUntilEffect = 20f;
    private float timeSinceLastEffect = 0;
    private int stressLevel = 0;
    private bool stressLevelChanged = false;
    private bool ringingPlaying = false;

    void Start()
    {
        playerCamera = GameObject.FindWithTag("MainCamera");
        //Remember to add this tag
        playerAudio = GameObject.FindWithTag("PlayerAudio");

    }
    // Update is called once per frame
    void Update()
    {

        switch (stressLevel)
        {
            case 0:
                break;
            case 1:
                LevelOne();
                break;
            case 2:
                LevelTwo();
                break;
            case 3:
                LevelThree();
                break;
            case 4:
                LevelFour();
                break;
            default:
                break;
        }
        //Stop the ear ringing if we leave level 4
        if (ringingPlaying && stressLevel <= 3 )
        {
            earRingingAudio.GetComponent<EarRingingSound>().StopEarRinging();
            ringingPlaying = false;
        }

        // bool that controls if OCD effects are active
        /*if (performOCDEffects)
         {
             // will start an OCD attack every timeUntilIncreasedEffects seconds if one is not actively occurring.
             timeSinceLastOCDAttack += Time.deltaTime;
             timeSinceLastEffect += Time.deltaTime;
             //Debug.Log (timeSinceLastOCDAttack);

             if (!activeAttack)
             {
                 if (timeSinceLastEffect >= timeUntilEffect)
                 {
                     Debug.Log ("OCD attack starting");
                     StartOCDAttack();
                     timeSinceLastEffect = 0;
                 }
                 activeAttack = true;
                 timeSinceLastOCDAttack = 0;
             }
             // if timeUntilIncreasedEffects seconds pass and player hasn't satisfied OCD urge, increase effect rate
             else if (timeSinceLastOCDAttack >= timeUntilIncreasedEffects && activeAttack)
             {
                 if (timeUntilEffect >= 4)
                 {
                     timeUntilEffect /= 2;
                 }
                 if (timeSinceLastEffect >= timeUntilEffect)
                 {
                     StartOCDAttack();
                     timeSinceLastEffect = 0;
                 }
                 timeSinceLastOCDAttack = 0;
             }
             else if (timeSinceLastEffect >= timeUntilEffect && activeAttack)
             {
                 StartOCDAttack();
                 timeSinceLastEffect = 0;
             }

         }*/
    }

    private void StartOCDAttack()
    {
        StartCoroutine(playerCamera.GetComponent<Blur>().BlurPulse());
        playerAudio.GetComponent<PlayerSounds>().PlayBreathingSound();
    }
    // Blur and Breathing every 20 seconds
    private void LevelOne()
    {
        timeUntilEffect = 20f;
        timeSinceLastEffect += Time.deltaTime;
        if (timeSinceLastEffect >= timeUntilEffect)
        {
            StartCoroutine(playerCamera.GetComponent<Blur>().BlurPulse());
            playerAudio.GetComponent<PlayerSounds>().PlayBreathingSound();
            timeSinceLastEffect = 0;
        }
    }
    // Blur, Breathing, and slight Vignette every 10 seconds
    private void LevelTwo()
    {
        timeUntilEffect = 10f;
        timeSinceLastEffect += Time.deltaTime;
        if (timeSinceLastEffect >= timeUntilEffect)
        {
            StartCoroutine(playerCamera.GetComponent<Blur>().BlurPulse());
            StartCoroutine(playerCamera.GetComponent<VignetteAndChromaticAberration>().VignettePulse(.3f));
            playerAudio.GetComponent<PlayerSounds>().PlayBreathingSound();
            timeSinceLastEffect = 0;
        }

    }
    // Blur, Breathing, and heavy Vignette every 8 seconds
    private void LevelThree()
    {
        timeUntilEffect = 8f;
        timeSinceLastEffect += Time.deltaTime;
        if (timeSinceLastEffect >= timeUntilEffect)
        {
            StartCoroutine(playerCamera.GetComponent<Blur>().BlurPulse());
            StartCoroutine(playerCamera.GetComponent<VignetteAndChromaticAberration>().VignettePulse(.5f));
            playerAudio.GetComponent<PlayerSounds>().PlayBreathingSound();
            timeSinceLastEffect = 0;
        }
    }
    // Blur, Breathing, heavy Vignette, every 8 seconds and constant medium ear riging
    private void LevelFour()
    {
        timeUntilEffect = 8f;
        timeSinceLastEffect += Time.deltaTime;
        if (timeSinceLastEffect >= timeUntilEffect)
        {
            StartCoroutine(playerCamera.GetComponent<Blur>().BlurPulse());
            StartCoroutine(playerCamera.GetComponent<VignetteAndChromaticAberration>().VignettePulse(.5f));
            playerAudio.GetComponent<PlayerSounds>().PlayBreathingSound();
            timeSinceLastEffect = 0;
        }
        // if we're not playing the ear ringing, start
        if (!ringingPlaying)
        {
            ringingPlaying = true;
            earRingingAudio.GetComponent<EarRingingSound>().PlayEarRinging(.3f);
        }
    }

    private void ResetEffects()
    {
        timeUntilEffect = 10;
        activeAttack = false;
        timeSinceLastOCDAttack = 0;
        timeSinceLastEffect = 0;
        stressLevel = 0;
    }
    public void StartOCDTimer()
    {
        //performOCDEffects = true;
    }
    public void StopOCDTimer()
    {
        // performOCDEffects = false;
        ResetEffects();
    }
    public void SetStressLevel(int level)
    {
        stressLevel = level;
    }
}
