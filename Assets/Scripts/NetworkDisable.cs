using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkDisable : Photon.MonoBehaviour {

    public Camera playerCam;
    public GameObject[] disableObjs;

    public GameObject[] mySideObj;
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
            foreach (GameObject obj in disableObjs)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject obj in mySideObj)
            {
                obj.SetActive(false);
            }
        }
    }
}
