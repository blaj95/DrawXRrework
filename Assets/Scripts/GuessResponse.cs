using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GuessResponse : Photon.MonoBehaviour {
    public GameObject[] texts;
    public List<Text> arResponseText;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       
           texts = GameObject.FindGameObjectsWithTag("CorrectText");
            foreach(GameObject go in texts)
            {
                Text text = go.GetComponent<Text>();
                if(!arResponseText.Contains(text))
                arResponseText.Add(text);
                
            }

        if (Input.GetKey(KeyCode.Space))
        {
            photonView.RPC("CorrectAnswer", PhotonTargets.All);
        }
        
	}

    [PunRPC]
    public void CorrectAnswer()
    {
        foreach(Text te in arResponseText)
        {
            te.text = "You got it!";
        }
    }
}
