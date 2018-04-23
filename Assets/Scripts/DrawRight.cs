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
    public PhotonView pv;

    // Use this for initialization
    void Start ()
    {

        
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
        //if(pv.isMine)
        //pv = player.GetComponent<PhotonView>();
        //if (RHandInstance.instance != null)
        //{
        //    controller = RHandInstance.instance.gameObject;
        //}
        player = GameObject.Find("Drawer(Clone)");
        if (player.GetComponent<PhotonView>().isMine)
            pv = player.GetComponent<PhotonView>();

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
            stroke.AddComponent<PhotonView>();
            //col = stroke.AddComponent<BoxCollider>();
            //col.center = stroke.gameObject.transform.localPosition;
            rig = stroke.GetComponent<Rigidbody>();
            rig.isKinematic = true;
            rig.useGravity = false;
            currLine = stroke.AddComponent<LineRenderer>();
            currLine.lineMaterial = GetCurrentColor();
            currLine.setWidth(width);

            numClicks++;
            pv.RPC("AddStroke", PhotonTargets.All);
        }
        else if (OVRInput.Get(button) && numClicks > 0)
        {
            currLine.AddPoint(controller.transform.position);


            pv.RPC("DrawLine", PhotonTargets.All, controller.transform.position);

            numClicks++;
        }
        else if (OVRInput.GetUp(button))
        {
            numClicks = 0;
            currLine = null;


            pv.RPC("SetNull", PhotonTargets.All);
        }
        if (currLine != null)
        {
            currLine.lineMaterial = GetCurrentColor();

            pv.RPC("SetColor", PhotonTargets.AllBuffered);
        }

        if (OVRInput.GetUp(OVRInput.Button.SecondaryThumbstickUp))
        {
            width = width + 0.01f;
            pv.RPC("IncreaseWidth", PhotonTargets.All);
        }
        else if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            width = width - 0.01f;
            if (width <= 0.01f)
            {
                width = 0.01f;
            }
            pv.RPC("DecreaseWidth", PhotonTargets.All);
        }


        if ((OVRInput.GetUp(buttonA)))
        {
            Debug.Log("CHANGE");
            pv.RPC("ChangeColor", PhotonTargets.AllBuffered);

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
        stroke.AddComponent<PhotonView>();
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
