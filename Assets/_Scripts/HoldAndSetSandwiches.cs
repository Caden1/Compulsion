using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAndSetSandwiches : MonoBehaviour
{
    public static bool twoSandwiches;
    private GameObject sandwichReference;

    // Use this for initialization
    void Start()
    {
        twoSandwiches = false;

        sandwichReference = GameObject.Find("2SandwichesPickUp"); // Need a reference to the original sandwiches.
    }

    public void GrabThenSetDown()
    {
        if (gameObject.name == "2SandwichesPickUp" && twoSandwiches == false)
        {
            SendMessage("PickUpAndHold", gameObject, SendMessageOptions.DontRequireReceiver);
        }
        else if (gameObject.name == "KitchenTableCollider" && twoSandwiches == true)
        {
            SendMessage("SetDown", SendMessageOptions.DontRequireReceiver);

            Destroy(sandwichReference); // Destroy the original plates.
            gameObject.transform.GetChild(8).GetComponent<MeshRenderer>().enabled = true;
            gameObject.transform.GetChild(9).GetComponent<MeshRenderer>().enabled = true;
            twoSandwiches = false;
        }
    }

    public void SetVarTrue()
    {
        twoSandwiches = true;
    }
}
