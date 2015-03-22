using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Windows.Kinect;

public class Moves : MonoBehaviour 
{
	private GameObject HandLeft;
	private GameObject HandRight;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (HandLeft == null && HandRight == null)
        {
			HandLeft = GameObject.Find("joint_HandLT");
			HandRight = GameObject.Find("joint_HandRT");
        }

		if(HandLeft != null && HandRight != null)
        {
			CheckForMove();
        }

	}


	void CheckForMove()
	{
		if((HandRight.transform.position - HandLeft.transform.position).sqrMagnitude < 0.1f)
		{
			Debug.Log ("Kameha-meha!");
		}
	}

}
