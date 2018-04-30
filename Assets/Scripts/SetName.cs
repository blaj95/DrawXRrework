using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetName : Photon.PunBehaviour {
    public Text _name;
    public CanvasRenderer rend;

    public PhotonPlayer player { get; private set; }

	// Use this for initialization
	void Start ()
    {
		
	}

    private void Awake()
    {
      
    }
    // Update is called once per frame
    public override void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        name = new System.Text.StringBuilder()
            .Append(photonView.owner.NickName)
            .Append(" [")
            .Append(photonView.viewID)
            .Append("]")
            .ToString();

        BroadcastMessage("OnInstantiate", info, SendMessageOptions.DontRequireReceiver);
    }

    [PunRPC]
    public void ShowName()
    {
        _name = GameObject.FindGameObjectWithTag("playerName").GetComponent<Text>();
        _name.text = PhotonNetwork.playerName;
    }
}
