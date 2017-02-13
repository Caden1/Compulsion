using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurTrigger : MonoBehaviour {

    public GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            mainCamera.GetComponent<Blur>().enabled = true;
            mainCamera.GetComponent<Blur>().pulse = true;
            StartCoroutine(mainCamera.GetComponent<Blur>().BlurPulse());
        }
    }
}
