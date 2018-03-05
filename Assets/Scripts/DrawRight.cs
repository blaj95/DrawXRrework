using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawRight : Photon.MonoBehaviour {

    public GameObject controller;
    public GameObject player;
    public Material lineMaterial;
    public float width;
    public OVRInput.Button button;
    public List<GameObject> lines;

    public OVRInput.Button buttonA;
    public Material color1;
    public Material color2;
    public Material color3;
    public Material color;

    private LineRenderer currLine;
    private int numClicks = 0;
    private Rigidbody rig;
    private BoxCollider col;
    private PhotonView photonView;

    // Use this for initialization
    void Start ()
    {

        photonView = PhotonView.Get(player);
        //photonView.RPC("setColor", PhotonTargets.AllBuffered, null);
        
    }

    private void Awake()
    {
        //photonView.RPC("setColor", PhotonTargets.AllBuffered, null);

        color = color1;
    }

    // Update is called once per frame
    void Update ()
    {

        //if (RHandInstance.instance != null)
        //{
        //    controller = RHandInstance.instance.gameObject;
        //}

        if (OVRInput.Get(button) && numClicks == 0)
        {
            GameObject stroke = new GameObject("stroke");
            stroke.tag = "stroke";
            lines.Add(stroke);
            //stroke.transform.parent = GameObject.FindGameObjectWithTag("Grouping").transform;
            stroke.AddComponent<MeshFilter>();
            stroke.AddComponent<MeshRenderer>();
            stroke.AddComponent<Rigidbody>();
            stroke.AddComponent<BoxCollider>();
            //col = stroke.AddComponent<BoxCollider>();
            //col.center = stroke.gameObject.transform.localPosition;
            rig = stroke.GetComponent<Rigidbody>();
            rig.isKinematic = true;
            rig.useGravity = false;
            currLine = stroke.AddComponent<LineRenderer>();
            currLine.lineMaterial = GetCurrentColor();
            currLine.setWidth(width);

            numClicks++;
            photonView.RPC("AddStroke", PhotonTargets.All, 0);
        }
        else if (OVRInput.Get(button) && numClicks > 0)
        {
            currLine.AddPoint(controller.transform.position);


            photonView.RPC("DrawLine", PhotonTargets.All, controller.transform.position);

            numClicks++;
        }
        else if (OVRInput.GetUp(button))
        {
            numClicks = 0;
            currLine = null;


            photonView.RPC("SetNull", PhotonTargets.All, 0);
        }
        if (currLine != null)
        {
            currLine.lineMaterial = GetCurrentColor();

            photonView.RPC("SetColor", PhotonTargets.AllBuffered, null);
        }

        if (OVRInput.GetUp(OVRInput.Button.SecondaryThumbstickUp))
        {
            width = width + 0.01f;
            photonView.RPC("IncreaseWidth", PhotonTargets.All, 0);
        }
        else if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            width = width - 0.01f;
            if (width <= 0.01f)
            {
                width = 0.01f;
            }
            photonView.RPC("DecreaseWidth", PhotonTargets.All, 0);
        }


        if ((OVRInput.GetUp(buttonA)))
        {
            Debug.Log("CHANGE");
            photonView.RPC("ChangeColor", PhotonTargets.AllBuffered, null);

            if (color == color1)
            {
                color = color2;
            }
            else if (color == color2)
            {
                color = color3;
            }
            else
            {
                color = color1;
            }

        }
    }

    public Material GetCurrentColor()
    {
        return this.color;
    }

    [PunRPC]
    public void setColor()
    {
        color = color1;
    }

    [PunRPC]
    public void AddStroke()
    {
        GameObject stroke = new GameObject("stroke");
        stroke.tag = "stroke";
        lines.Add(stroke);
        //stroke.transform.parent = GameObject.FindGameObjectWithTag("Grouping").transform;
        stroke.AddComponent<MeshFilter>();
        stroke.AddComponent<MeshRenderer>();
        stroke.AddComponent<Rigidbody>();
        stroke.AddComponent<BoxCollider>();
        //col = stroke.AddComponent<BoxCollider>();
        //col.center = stroke.gameObject.transform.localPosition;
        rig = stroke.GetComponent<Rigidbody>();
        //rig.isKinematic = true;
        rig.useGravity = false;
        currLine = stroke.AddComponent<LineRenderer>();
        currLine.lineMaterial = new Material(lineMaterial);
        currLine.setWidth(width);

        numClicks++;


    }

    [PunRPC]
    public void DrawLine(Vector3 point)
    {
        currLine.AddPoint(point);
    }

    [PunRPC]
    public void SetNull()
    {
        currLine = null;
    }

    [PunRPC]
    public void SetColor()
    {
        if (currLine != null)
        {
            currLine.lineMaterial = GetCurrentColor();
        }
    }

    [PunRPC]
    public void IncreaseWidth()
    {
        width = width + 0.01f;
    }

    [PunRPC]
    public void DecreaseWidth()
    {
        width = width - 0.01f;
        if (width <= 0.01f)
        {
            width = 0.01f;
        }
    }

    [PunRPC]
    public void ChangeColor()
    {
        if (color == color1)
        {
            color = color2;
        }
        else if (color == color2)
        {
            color = color3;
        }
        else
        {
            color = color1;
        }
    }
}
