using UnityEngine;
using System.Collections;

public class CameraHeadMapping : MonoBehaviour 
{
    private GameObject FirstPersonCamera;
    private GameObject Head;

	// Use this for initialization
	void Start () 
    {
		FirstPersonCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Head == null)
        {
			Head = GameObject.Find("joint_Head");
        }

        if(Head != null)
        {
			FirstPersonCamera.transform.position = Head.transform.position;
            //FirstPersonCamera.transform.rotation = Head.transform.rotation;
        }
	}
}
