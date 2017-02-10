using UnityEngine;
using System.Collections;

public class PickupObject : MonoBehaviour {

    private GameObject mainCamera;
    private bool carrying;
    //private GameObject carriedObject;

    public float floatDistance = 3f;
    public float floatSpeed = 3f;
    public float touchRange = 3f;


    public LayerMask pickUpMask;
    public LayerMask activatableMask;
    

    private Ray ray;
    private RaycastHit hit;
    private GameObject objectHeld;

    // Use this for initialization
    void Start ()
    {
        mainCamera = GameObject.FindWithTag("MainCamera"); // Sets the main camera to variable mainCamera by finding its tag 

	}


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, touchRange, pickUpMask))
            {
                objectHeld = hit.collider.gameObject;
                objectHeld.GetComponent<Rigidbody>().useGravity = false;
            }
        }
        //else if (Input.GetMouseButton(0))
        //{
        //    if(objectHeld != null)
        //    {
        //        Carry(objectHeld);
        //    }
        //}
        else if (Input.GetMouseButtonUp(0))
        {
            if(objectHeld != null)
            {
                DropObject();
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, touchRange, activatableMask))
                {
                    hit.transform.gameObject.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }


    void FixedUpdate()
    {
        if (objectHeld != null)
        {
            Carry(objectHeld);
        }
    }

    private void Carry(GameObject obj)
    {
        // Object floats in front of player at "floatDistance"
        obj.transform.position = Vector3.Lerp(obj.transform.position, mainCamera.transform.position + mainCamera.transform.forward * floatDistance, floatSpeed);

        // Prevents object from rotating while held
        obj.transform.rotation = Quaternion.identity; // !! CHANGE FOR ROTATING WITH BODY !!
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
