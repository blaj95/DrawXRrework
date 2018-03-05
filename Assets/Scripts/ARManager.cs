using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARManager : MonoBehaviour {

    public GameObject head;

    public static ARManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
