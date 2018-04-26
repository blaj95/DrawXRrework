using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AndroidNetworkManager : MonoBehaviour
{
    public byte Version = 1;

    public virtual void ButtonStart()
    {
        SceneManager.LoadScene(1);
    }
    
}
