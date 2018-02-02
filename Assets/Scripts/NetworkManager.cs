using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {

    public string version;

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings(version);
	}

    void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Gloabal", new RoomOptions() { maxPlayers = 3 }, null);
    }
	
    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Personaje", transform.position, transform.rotation, 0);
    }
	
}
