using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookCookies : MonoBehaviour
{
    public static bool uncookedCookies;
    private GameObject uncookedCookiesReference;
    private Transform putInOvenPosition;

    public static bool cookedCookies;
    private GameObject cookedCookiesReference;

    public static bool cookiesAreCooked;

    private OvenDoor ovenDoorScript;

    // Use this for initialization
    void Start()
    {
        uncookedCookies = false;
        cookedCookies = false;
        cookiesAreCooked = false;

        uncookedCookiesReference = GameObject.Find("UncookedCookies"); // Need a reference to the original Uncooked Cookies.
        cookedCookiesReference = GameObject.Find("CookedCookies"); // Need a reference to the original Cooked Cookies.
        putInOvenPosition = GameObject.Find("UncookedCookiePlacement").transform; // The position of where to put the uncooked cookies in the oven.

        GameObject ovenDoor = GameObject.Find("OvenDoor");
        ovenDoorScript = ovenDoor.GetComponent<OvenDoor>();
    }

    void Update()
    {
        if (cookiesAreCooked == true && ovenDoorScript.IsOpen == false)
        {
            Destroy(uncookedCookiesReference);
            cookedCookiesReference.GetComponent<MeshRenderer>().enabled = true;
        }
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

            uncookedCookiesReference.transform.position = putInOvenPosition.position + new Vector3(-0.4f, -0.05f, 0f); // New position of the uncooked cookies. (in th oven). Needed an offset added to it.
            uncookedCookiesReference.transform.parent = putInOvenPosition; // Child the uncooked cookies to the collider so the player lets go of it.
            uncookedCookiesReference.name = "PlacedUncookedCookies"; // Rename the object so it cannot be picked up again right away.
            //Destroy(uncookedCookiesReference); // Destroy the original plates.
            //gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            //gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
            uncookedCookies = false;

            Invoke("CookCookiesAndPlaySound", 10.0f);
        }
    }

    public void SetVarTrue()
    {
        uncookedCookies = true;
        cookedCookies = true;
    }

    private void CookCookiesAndPlaySound()
    {
        cookiesAreCooked = true;
        Debug.Log("Cookies are done.");
    }
}
