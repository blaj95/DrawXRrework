using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    public bool isDrawer;
    public bool isSpectator;

    public GameObject spawnArea;

    public bool AutoConnect = true;

    public byte Version = 1;

    private bool ConnectInUpdate = true;

    public virtual void Start()
    {
        PhotonNetwork.ConnectUsingSettings(Version + "." + SceneManagerHelper.ActiveSceneBuildIndex);
    }

    public virtual void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby(). This client is connected and does get a room-list, which gets stored as PhotonNetwork.GetRoomList(). This script now calls: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public virtual void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.LogError("Cause: " + cause);
    }

    public void OnJoinedRoom()
    {
        if (isDrawer)
        {
            Debug.Log("Drawer Joined Room");
            PhotonNetwork.Instantiate("Drawer", Vector3.zero, Quaternion.identity, 0);
        }
       else if (isSpectator)
       {
            PhotonNetwork.Instantiate("ARPlayer", new Vector3(0, 0, 7.5f), new Quaternion(0, 180, 0, 0),0);
       }
       else
       {
            Debug.Log("No Player Selected");
       }
       
    }
    // Update is called once per frame
    void Update () {
		
	}
}
