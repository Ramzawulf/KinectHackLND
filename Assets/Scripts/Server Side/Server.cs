using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class Server : MonoBehaviour {

    public int port = 25001;
    private string defaultIP = "127.0.0.1";
    public string connectionIP;
    public Text statusLabel;
    public Text ipField;
    public InputField iField;

    public Transform PlayerOnePrefab;
    public Transform PlayerTwoPrefab;
    public List<TestCube> PlayerList;

	void Start () {
        PlayerList = new List<TestCube>();
	}

	void Update () {
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

    public void StartServer()
    {
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            Network.InitializeServer(32, port, false);
        }
        
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

    public void OnServerInitialized()
    {
        Debug.Log("server started");
    }

    void OnPlayerConnected(NetworkPlayer player)
    {
        SpawnPlayer(player);
    }

    void SpawnPlayer(NetworkPlayer player) {
        int playerNumber = Convert.ToInt32(player.ToString());
        Transform newPlayerTransform = (Transform)Network.Instantiate(PlayerOnePrefab, transform.position, transform.rotation, playerNumber);
    }
}
