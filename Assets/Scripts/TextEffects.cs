using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextEffects : MonoBehaviour {

    public Material mat;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime, Space.World);
        mat.color = Color.Lerp(Color.red,Color.blue, Mathf.PingPong(Time.time, 3));
    }
}
