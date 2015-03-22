using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {

    public int port = 25001;
    private string defaultIP = "127.0.0.1";


	public string typeName = "Dojo";
	public string gameName = "Kinect Fight Game";
    public string connectionIP;
    public Text statusLabel;
    public Text ipField;
    public InputField iField;

    public Transform PlayerOnePrefab;
    public Transform PlayerTwoPrefab;
	public KinectManager knctManagerPrefab;
	public Transform P1SpawnPoint;
	public Transform P2SpawnPoint;
	private List<GameObject> players;

	void Awake(){
		players = new List<GameObject> ();
	}

	void Update () {
			UpdateStatusLabel ();
	}
	
	void OnConnectedToServer()
	{
		SpawnPlayer();
	}
	
	private void SpawnPlayer()
	{
		if (players.Count == 0) {
			//Spawn P1
			players.Add (Network.Instantiate (PlayerOnePrefab, P1SpawnPoint.position, Quaternion.identity, 0) as GameObject);
				Network.Instantiate(knctManagerPrefab, new Vector3(0,0,0), Quaternion.identity, 99);
		} else if (players.Count == 1) {
			players.Add (Network.Instantiate (PlayerOnePrefab, P2SpawnPoint.position, Quaternion.identity, 0) as GameObject);
		}
	}

    public void StartServer()
    {
		Network.InitializeServer(2, port, !Network.HavePublicAddress());
	}

    public void StopServer()
    {
        if (Network.peerType == NetworkPeerType.Server)
        {
          Network.Disconnect(200);
        }
    }

    public void ConnectAsClient()
    {
        if (iField == null || iField.text == null)
        {
            connectionIP = defaultIP;
        }
        else
        {
            connectionIP = iField.text;
        }

        Network.Connect(connectionIP, port);
    }
	
	private void UpdateStatusLabel(){
		if (Network.peerType == NetworkPeerType.Disconnected) {
			statusLabel.text = "Disconnected";
		}
		else if (Network.peerType == NetworkPeerType.Client)
		{
			statusLabel.text = "Connected as client.";
		}else if (Network.peerType == NetworkPeerType.Server){
			
			statusLabel.text = "Connected as server";
		}
	}
}
