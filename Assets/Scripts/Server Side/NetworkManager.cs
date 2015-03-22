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
	public Text numPlayers;
    public InputField iField;

	public GameObject pillar;

    public Transform PlayerOnePrefab;
    public Transform PlayerTwoPrefab;
	public KinectManager knctManagerPrefab;
	public Transform P1SpawnPoint;
	public Transform P2SpawnPoint;
	private bool isP1Spawned = false;


	void Awake(){

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
		if (Network.connections.Length <= 1) {
			Network.Instantiate (PlayerOnePrefab, new Vector3(UnityEngine.Random.Range(-15f, 15f), 0 ,UnityEngine.Random.Range(-1.5f,1.5f)), Quaternion.identity, 0);
			Network.Instantiate(knctManagerPrefab, new Vector3(15f,1.5f,0), Quaternion.identity, 99);
		} else {
			Network.Instantiate (PlayerOnePrefab, new Vector3(UnityEngine.Random.Range(-15f, 15f), 0 ,UnityEngine.Random.Range(-1.5f,1.5f)), Quaternion.identity, 0);
			pillar.transform.position = new Vector3(100,100,100);
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

		numPlayers.text = Network.connections.Length.ToString();
	}
}
