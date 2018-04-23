using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkDisable : Photon.MonoBehaviour {

    public Camera playerCam;
    public GameObject[] disableObjs;
	// Use this for initialization
	void Start ()
    {
		
	}

    private void Awake()
    {
        if (!photonView.isMine)
        {
            playerCam.enabled = false;
            foreach(GameObject obj in disableObjs)
            {
                obj.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (!photonView.isMine)
        {
            playerCam.enabled = false;
        }
    }
}
