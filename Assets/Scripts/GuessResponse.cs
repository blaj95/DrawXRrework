using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GuessResponse : Photon.MonoBehaviour {
    public GameObject[] texts;
    public GameObject[] scoretexts;
    public List<Text> arResponseText;
    public List<Text> arScoreText;
    public string incorrect = "NOOOOOPE!";
    public string correct = "You got it!";

    public int score = 0;
    
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

        scoretexts = GameObject.FindGameObjectsWithTag("Score");
        foreach (GameObject go in scoretexts)
        {
            Text text = go.GetComponent<Text>();
            if (!arScoreText.Contains(text))
                arScoreText.Add(text);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "GotItButton")
        {
            photonView.RPC("CorrectAnswer", PhotonTargets.All, correct);
            score++;
            photonView.RPC("AddScore", PhotonTargets.All);
            
        }

        if (other.gameObject.tag == "WrongButton")
            photonView.RPC("WrongAnswer", PhotonTargets.All, incorrect);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GotItButton" || other.gameObject.tag == "WrongButton")
            photonView.RPC("ClearARUI", PhotonTargets.All);
    }

    [PunRPC]
    public void CorrectAnswer(string response)
    {
        foreach(Text te in arResponseText)
        {
            te.text = response;
        }
    }

    [PunRPC]
    public void WrongAnswer(string response)
    {
        foreach (Text te in arResponseText)
        {
            te.text = response;
        }
    }

    [PunRPC]
    public void ClearARUI()
    {
        foreach (Text te in arResponseText)
        {
            te.text = "";
        }
    }

    [PunRPC]
    public void AddScore()
    {
        foreach (Text te in arScoreText)
        {
            te.text = score.ToString();
        }
    }
}
