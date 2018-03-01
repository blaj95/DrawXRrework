using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingGrab : MonoBehaviour {
    
    public GameObject drawGroup;
    [SerializeField]
    private Rigidbody rb;
    private OVRGrabbable ovrGrab;
    private Collider col;
    public bool hasRb = false;
    public bool hasCol = false;

    private GameObject grabbedObj;
    private bool grabbing;
    public float grabRadius;
    public LayerMask grabMask;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (OVRInput.GetUp(OVRInput.Button.Two))
        {
            if (hasRb == false && hasCol == false)
            {
                drawGroup.AddComponent<Rigidbody>();
                drawGroup.AddComponent<BoxCollider>();
                col = drawGroup.GetComponent<BoxCollider>();
                rb = drawGroup.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                rb.useGravity = false;
                hasCol = true;
                hasRb = true;
                col.isTrigger = true;
                //ovrGrab = drawGroup.gameObject.GetComponent<OVRGrabbable>();
                //ovrGrab.enabled = true;
                //ovrGrab.grabPoints.SetValue(col, 0);
            }
            else
            {
                Debug.Log("Already grouped");
            }
            
        }

        if (Input.GetAxis("RHandTrigger") == 1)
        {
            GrabObject();
        }
        if (Input.GetAxis("RHandTrigger") < 1)
        {
            DropObject();
        }

    }

    void GrabObject()
    {
        grabbing = true;

        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);
        if(hits.Length > 0)
        {
            int closestHit = 0;
            for(int i = 0; i < hits.Length; i++)
            {
                if(hits[i].distance > hits[closestHit].distance)
                {
                    closestHit = i;
                }
            }
            grabbedObj = hits[closestHit].transform.gameObject;
            grabbedObj.GetComponent<Rigidbody>().isKinematic = true;
            grabbedObj.transform.position = transform.position;

        }

    }

    void DropObject()
    {
        grabbing = false;
    }
}
