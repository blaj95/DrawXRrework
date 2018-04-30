using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AndroidNetworkManager : Photon.PunBehaviour
{
    public byte Version = 1;
    public Text playerName;
    
    public virtual void ButtonStart()
    {
        SceneManager.LoadScene(1);
        PhotonNetwork.playerName = playerName.text;
    }

    private void Update()
    {
        playerName = GameObject.FindGameObjectWithTag("NameText").GetComponent<Text>();
    }

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

}
