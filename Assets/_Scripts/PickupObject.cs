using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {

    private GameObject mainCamera;
    private bool carrying;

    public float floatDistance = 3f;
    public float floatSpeed = 3f;
    public float touchRange = 3f;


    public LayerMask interactable;
    //public LayerMask pickUpMask;
    public LayerMask activatableMask;
    //public LayerMask keepMask; // Caden Added.
    //public LayerMask OCDTaskMask; // Caden Added.
    public GameObject reticle;


    private Ray ray;
    private RaycastHit hit;
    private GameObject objectHeld;
    private Vector2 screencenter;

    // Use this for initialization
    void Start ()
    {
        mainCamera = GameObject.FindWithTag("MainCamera"); // Sets the main camera to variable mainCamera by finding its tag 
        screencenter = new Vector2(Screen.width/2, Screen.height/2);
    }


    private void Update()
    {
        ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(screencenter);
        if(Physics.Raycast(ray, out hit, touchRange, interactable))
        {
            reticle.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                //ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                //if (Physics.Raycast(ray, out hit, touchRange, pickUpMask))
                //{
                //    objectHeld = hit.collider.gameObject;
                //    objectHeld.GetComponent<Rigidbody>().useGravity = false;
                //    Carry();
                //}
                switch (hit.transform.tag) // Caden Added
                {
                    // For picking things up and setting them down (general)
                    case "KeepThenSet":
                        // Calls the Grab function in the script attached to this gameObject
                        hit.transform.gameObject.SendMessage("GrabThenSetDown", SendMessageOptions.DontRequireReceiver);
                        // Calls the Scrub function in the script attached to this gameObject
                        hit.transform.gameObject.SendMessage("Scrub", SendMessageOptions.DontRequireReceiver);
                        break;
                }
                /*
                if (hit.transform.tag == "Keep")
                {
                    // Calls the Grab function in the script attached to this gameObject????
                    hit.transform.gameObject.SendMessage("Grab", SendMessageOptions.DontRequireReceiver); // Caden Added
                }
                */
                
                if (Physics.Raycast(ray, out hit, touchRange, activatableMask))
                {
                    objectHeld = hit.collider.gameObject;
                }
                //else if (Physics.Raycast(ray, out hit, touchRange, keepMask)) // Caden Added
                //{
                    //objectHeld = hit.collider.gameObject;
                    //hit.transform.gameObject.SendMessage("Grab", SendMessageOptions.DontRequireReceiver); // Caden Added
                //}
                //else if (Physics.Raycast(ray, out hit, touchRange, OCDTaskMask)) // Caden Added
                //{
                    //hit.transform.gameObject.SendMessage("OCDTask", SendMessageOptions.DontRequireReceiver); // Caden Added
                //}
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (objectHeld != null)
                {
                    //if (((1 << objectHeld.layer) & pickUpMask) != 0)
                    //{
                    //    DropObject();
                    //}
                    if (((1 << objectHeld.layer) & activatableMask) != 0)
                    {
                        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out hit, touchRange, activatableMask))
                        {
                            hit.transform.gameObject.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
            }
        }
        else
        {
            reticle.SetActive(false);
        }    
    }

    //private void FixedUpdate()
    //{
    //    if (objectHeld != null)
    //    {
    //        Carry(objectHeld);
    //    }
    //}

    private void Carry()
    {       
        //TODO: CREATE LERP TOL
        //TODO: CREATE COLLISION DETECTION
        // Object floats in front of player at "floatDistance"
        objectHeld.transform.position = 
            Vector3.Lerp(objectHeld.transform.position, 
            mainCamera.transform.position + (mainCamera.transform.forward * floatDistance), 
            floatSpeed * Time.deltaTime);

        // Prevents object from rotating while held
        objectHeld.transform.rotation = Quaternion.identity; // !! CHANGE FOR ROTATING WITH BODY !!

    }

    //private void Pickup()
    //{
    //    if (Input.GetMouseButton(0)) // On left click hold
    //    {
    //        // Middle of Screen
    //        int x = Screen.width / 2;
    //        int y = Screen.height / 2;

    //        // The ray
    //        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
    //        RaycastHit hit;

    //        // Shoots the ray
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            //Debug.Log(hit.distance);
                
    //            // If object hit is whithin range
    //            if (hit.distance <= touchRange)
    //            {
    //                // Checks if object has the Pickupable script
    //                //Pickupable p = hit.collider.GetComponent<Pickupable>();


				//	if (hit.collider.tag == "Pickupable") // Objects that can be held need the "Pickupable" tag
    //                {
    //                    carrying = true;
				//		carriedObject = hit.collider.gameObject;

    //                    // While carrying, object is unaffected by gravity
				//		hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
    //                }
    //            }
    //        }
    //    }
    //}

    private void DropObject()
    {
        //if (Input.GetMouseButtonUp(0)) // On left click up
        //{
            //carrying = false;
            objectHeld.gameObject.GetComponent<Rigidbody>().useGravity = true;
            objectHeld = null;
        //}
    }
}
