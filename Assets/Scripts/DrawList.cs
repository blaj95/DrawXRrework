using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawList : MonoBehaviour {

    public string[] Topics;
    public Text topictext;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            string randomTopic = Topics[Random.Range(0, Topics.Length)];
            topictext.text = randomTopic;
        }
        
	}
}
