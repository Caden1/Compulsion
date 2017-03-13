using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAndSetForksKnives : MonoBehaviour
{
    private static bool forkAndKnife;

    // Use this for initialization
    void Start ()
    {
        forkAndKnife = false;
    }

    public void GrabThenSetDown()
    {
        if (gameObject.name == "ForkKnifePickup" && forkAndKnife == false)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.GetChild(3).GetComponent<MeshRenderer>().enabled = false;
            forkAndKnife = true;
        }
        else if (gameObject.name == "KitchenTableCollider" && forkAndKnife == true)
        {
            // Specail cases becasue the children for fork and knife start at index 2
            gameObject.transform.GetChild(2).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(3).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(4).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(5).GetComponent<MeshRenderer>().enabled = true;
            forkAndKnife = false;
        }
    }
}
