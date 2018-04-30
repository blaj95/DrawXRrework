using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NicknameText : MonoBehaviour {

    void OnInstantiate(PhotonMessageInfo info)
    {
        var pView = GetComponentInParent<PhotonView>();
        if (pView.isMine)
        {
            gameObject.SetActive(false);
            return;
        }

        GetComponent<Text>().text = pView.owner.NickName;
    }
}
