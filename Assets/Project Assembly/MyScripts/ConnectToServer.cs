using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
//using System.Threading;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start() {
        PhotonNetwork.ConnectUsingSettings();
        //StartCoroutine(StallScriptExecution());
    }

    IEnumerator StallScriptExecution() {
        yield return new WaitForSeconds(3f);
        Debug.Log("after 3 seconds:");
    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby();
        StartCoroutine(StallScriptExecution());
    }

    public override void OnJoinedLobby() {
        SceneManager.LoadScene("Loading Screen Scene");

        SceneManager.LoadScene("Lobby Scene");
    }

    // This method is called whenever the list of available rooms is updated
    public override void OnRoomListUpdate(List<RoomInfo> roomList) {
        Debug.Log("Room list updated!");
        foreach (RoomInfo room in roomList) {
            // Example: Print information about each room
            Debug.Log("Room Name: " + room.Name + ", Players: " + room.PlayerCount + "/" + room.MaxPlayers);
        }
    }
}
