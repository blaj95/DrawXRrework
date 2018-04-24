using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour {

    public GameObject eraser;
    public GameObject[] strokes;
    private MeshCollider rend;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        eraser = GameObject.Find("Drawer(Clone)/TrackingSpace/RightHandAnchor/Eraser");
        strokes = GameObject.FindGameObjectsWithTag("stroke");
        foreach(GameObject go in strokes)
        {
            rend = go.GetComponent<MeshCollider>();
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            eraser.SetActive(true);
            rend.convex = true;
        }
        else
        {
            eraser.SetActive(false);
            rend.convex = false;
        }
    }

    public void Erase(Collision other)
    { 
            Debug.Log("ERASE");
            Destroy(other.gameObject);
        
    }
}
