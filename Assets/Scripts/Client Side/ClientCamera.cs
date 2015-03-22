using UnityEngine;
using System.Collections;

public class ClientCamera : MonoBehaviour {

	private NetworkView nwView;

	void Start (){
		nwView = gameObject.GetComponent<NetworkView> ();
		if(Network.isClient){
			if(nwView.isMine){
				Camera.main.enabled = false;
			}
		}
	}
}
