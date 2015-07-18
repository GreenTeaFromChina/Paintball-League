using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public Camera standbyCamera;
	SpawnSpot[] spawnSpots;
	// Use this for initialization
	void Start () {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot> ();
		Connect ();
	}
	
	void Connect() {
		PhotonNetwork.ConnectUsingSettings ("Project WTF SERVER");

	}

	void OnGUI() {
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

	void OnJoinedLobby() {
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed() {
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom() {
		SpawnMyPlayer ();
	}

	void SpawnMyPlayer() {
		if (spawnSpots == null) {
			Debug.LogError ("WTF?!?!?!!?");
			return;
		}
		SpawnSpot mySpawnSpot = spawnSpots [ Random.Range (0, spawnSpots.Length) ];
		PhotonNetwork.Instantiate("FPSController", mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
		standbyCamera.enabled = false;

	}

}