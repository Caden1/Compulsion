using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookCookies : MonoBehaviour
{
    public static bool uncookedCookies;
    private GameObject uncookedCookiesReference;
    private Transform putInOvenPosition;

    // Use this for initialization
    void Start()
    {
        uncookedCookies = false;

        uncookedCookiesReference = GameObject.Find("UncookedCookies"); // Need a reference to the original Uncooked Cookies.

        putInOvenPosition = GameObject.Find("UncookedCookiePlacement").transform; // The position of where to put the uncooked cookies in the oven.
    }

    public void GrabThenSetDown()
    {
        if (gameObject.name == "UncookedCookies" && uncookedCookies == false)
        {
            SendMessage("PickUpAndHold", gameObject, SendMessageOptions.DontRequireReceiver);
        }
        else if (gameObject.name == "UncookedCookiePlacement" && uncookedCookies == true)
        {
            SendMessage("SetDown", SendMessageOptions.DontRequireReceiver);

            uncookedCookiesReference.transform.position = putInOvenPosition.position;
            uncookedCookiesReference.transform.parent = putInOvenPosition;
            //Destroy(uncookedCookiesReference); // Destroy the original plates.
            //gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            //gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            uncookedCookies = false;
        }
    }

    public void SetVarTrue()
    {
        uncookedCookies = true;
    }
}
