using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAndSetPlates : MonoBehaviour
{
    public static bool twoPlates;
    private GameObject plateReference;

    // Use this for initialization
    void Start ()
    {
        twoPlates = false;

        plateReference = GameObject.Find("2PlatesPickup"); // Need a reference to the original plates.
    }

    public void GrabThenSetDown()
    {
        if (gameObject.name == "2PlatesPickup" && twoPlates == false)
        {
            SendMessage("PickUpAndHold", gameObject, SendMessageOptions.DontRequireReceiver);
        }
        else if (gameObject.name == "KitchenTableCollider" && twoPlates == true)
        {
            SendMessage("SetDown", SendMessageOptions.DontRequireReceiver);

            Destroy(plateReference); // Destroy the original plates.
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            twoPlates = false;
        }
    }

    public void SetVarTrue()
    {
        twoPlates = true;
    }
}
