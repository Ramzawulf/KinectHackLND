using UnityEngine;
using System.Collections;

public class ServerCamera : MonoBehaviour {

	private NetworkView nwView;
	private GameObject mainCamera;
	public Transform head;
	
	void Awake(){
		nwView = GetComponent<NetworkView> ();
		mainCamera = Camera.main.gameObject;
	}
	void Start (){
		if(Network.isServer){
			if(nwView.isMine){
				mainCamera.transform.position = new Vector3(0,1.5f,-17.86f);
			}
		}
	}
}