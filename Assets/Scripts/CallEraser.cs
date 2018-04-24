using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEraser : MonoBehaviour {

    public Eraser erase;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        erase = GameObject.Find("Drawer(Clone)").GetComponent<Eraser>();
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "stroke")
        {
            Debug.Log("Stroke");
            erase.Erase(other);
        }
        
    }
}
