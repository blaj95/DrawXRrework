﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetName : Photon.MonoBehaviour {
    public Text _name;
    public CanvasRenderer rend;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (photonView.isMine)
        {
            _name = GameObject.FindGameObjectWithTag("playerName").GetComponent<Text>();
            _name.text = PhotonNetwork.playerName;
            photonView.RPC("ShowName", PhotonTargets.Others);
        }
       
	}

    [PunRPC]
    public void ShowName()
    {
        _name = GameObject.FindGameObjectWithTag("playerName").GetComponent<Text>();
        _name.text = PhotonNetwork.playerName;
    }
}