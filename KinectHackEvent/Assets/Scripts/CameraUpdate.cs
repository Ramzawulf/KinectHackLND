using UnityEngine;
using System.Collections;

public class CameraUpdate : MonoBehaviour 
{
    private GameObject FirstPersonCamera;
    private GameObject Head;

	// Use this for initialization
	void Start () 
    {
        FirstPersonCamera = GameObject.Find("FirstPersonCamera");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Head == null)
        {
            Head = GameObject.Find("Head");
        }

        if(Head != null)
        {
            FirstPersonCamera.transform.position = Head.transform.position;
            FirstPersonCamera.transform.rotation = Head.transform.rotation;
        }
	}
}
