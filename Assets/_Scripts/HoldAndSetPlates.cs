using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAndSetPlates : MonoBehaviour
{
    private static bool twoPlates;

    // Use this for initialization
    void Start ()
    {
        twoPlates = false;
    }

    public void GrabThenSetDown()
    {
        if (gameObject.name == "2PlatesPickup" && twoPlates == false)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;
            twoPlates = true;
        }
        else if (gameObject.name == "KitchenTableCollider" && twoPlates == true)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            twoPlates = false;
        }
    }
}
