using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

    public GameObject spectatorPrefab;

    public GameObject headPrefab;
    public GameObject l_handPrefab;
    public GameObject r_handPrefab;

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
        Debug.Log("Joined Room");
        PhotonNetwork.Instantiate("Drawer", Vector3.zero, Quaternion.identity, 0);
        //Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");

        //if (!GOManager.instance.isSpectator)
        //{ // don't instantiate gameobjects if player is not in VR
        //    Debug.Log("VR Player entered room!");
        //    GameObject head = PhotonNetwork.Instantiate(headPrefab.name, RiftManager.Instance.head.transform.position, RiftManager.Instance.head.transform.rotation, 0);
        //    GameObject lArm = PhotonNetwork.Instantiate(l_handPrefab.name, RiftManager.Instance.leftHand.transform.position, RiftManager.Instance.leftHand.transform.rotation, 0);
        //    GameObject rArm = PhotonNetwork.Instantiate(r_handPrefab.name, RiftManager.Instance.rightHand.transform.position, RiftManager.Instance.rightHand.transform.rotation, 0);
        //}
        //else
        //{
        //    var arGameobject = ARManager.Instance.gameObject;
        //    var spawnPosition = spawnArea.transform.position;

        //    var lookPos = spawnPosition - arGameobject.transform.position;
        //    var rotation = Quaternion.LookRotation(lookPos);

        //    if (PhotonNetwork.playerList.Length == 1)
        //    {
        //        arGameobject.transform.position = new Vector3(spawnPosition.x + 2f, 0f, spawnPosition.z + 2f);
        //        arGameobject.transform.rotation = Quaternion.Slerp(arGameobject.transform.rotation, rotation, Time.deltaTime * 2);
        //    }
        //    else if (PhotonNetwork.playerList.Length == 2)
        //    {
        //        arGameobject.transform.position = new Vector3(spawnPosition.x + -2f, 0f, spawnPosition.z + -2f);
        //        arGameobject.transform.rotation = Quaternion.Slerp(arGameobject.transform.rotation, rotation, Time.deltaTime * 2);
        //    }
        //    else if (PhotonNetwork.playerList.Length == 3)
        //    {
        //        arGameobject.transform.position = new Vector3(spawnPosition.x + 2f, 0f, spawnPosition.z + -2f);
        //        arGameobject.transform.rotation = Quaternion.Slerp(arGameobject.transform.rotation, rotation, Time.deltaTime * 2);
        //    }
        //    else
        //    {
        //        arGameobject.transform.position = new Vector3(spawnPosition.x + -2f, 0f, spawnPosition.z + 2f);
        //        arGameobject.transform.rotation = Quaternion.Slerp(arGameobject.transform.rotation, rotation, Time.deltaTime * 2);
        //    }

        //    GameObject arHead = PhotonNetwork.Instantiate(spectatorPrefab.name, ARManager.Instance.head.transform.position, ARManager.Instance.head.transform.rotation, 0);
        //    Debug.Log("AR Player entered room!");
        //}
    }
    // Update is called once per frame
    void Update () {
		
	}
}
