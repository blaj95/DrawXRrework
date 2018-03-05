using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOManager : MonoBehaviour {

    public Boolean isSpectator;

    public GameObject[] arGameObjects; // all AR game objects that will be turned off on Rift 
    public GameObject[] riftGameObjects; // all rift objects that will be turned off in AR

    public static GOManager instance;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        instance = this;

        if (isSpectator)
        {
            for (int i = 0; i < riftGameObjects.Length - 1; i++)
            {
                //Destroy(riftGameObjects[i]);
                riftGameObjects[i].SetActive(false);
            };
        }
        else
        {
            for (int i = 0; i < arGameObjects.Length - 1; i++)
            {
                //Destroy(arGameObjects[i], 1f);
                arGameObjects[i].SetActive(false);
            };
        }
    }
}
