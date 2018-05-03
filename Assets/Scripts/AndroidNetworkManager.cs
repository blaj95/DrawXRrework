using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AndroidNetworkManager : Photon.PunBehaviour
{
    public byte Version = 1;
    public Text playerName;
    public bool Drawer = true;

    public virtual void ButtonStart()
    {
        SceneManager.LoadScene(1);
        PhotonNetwork.playerName = playerName.text;
    }

    private void Update()
    {
        playerName = GameObject.FindGameObjectWithTag("NameText").GetComponent<Text>();
        if(Drawer == true)
        {
            SceneManager.LoadScene(1);
        }
    }

   

}
