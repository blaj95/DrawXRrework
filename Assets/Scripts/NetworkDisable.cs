using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkDisable : Photon.MonoBehaviour {

    public Camera playerCam;
	// Use this for initialization
	void Start ()
    {
		
	}

    private void Awake()
    {
        if (!photonView.isMine)
        {

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
