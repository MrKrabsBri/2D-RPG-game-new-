using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviourPun {
    // [SerializeField] PhotonView myPV;

    public GameObject monsterPrefab;
    public List<GameObject> prefabInstancesList = new List<GameObject>();

    [SerializeField] float xCoords1;
    [SerializeField] float yCoords1;
    [SerializeField] float xCoords2;
    [SerializeField] float yCoords2;

    [SerializeField] int monsterCount = 2;
    MonsterList monsterList;

    // Start is called before the first frame update
    void Start() {


        if (PhotonNetwork.IsMasterClient) {

            for (int i = 0; i < monsterCount; i++) {


                Vector2 position1 = new Vector2(xCoords1, yCoords1);
                GameObject monsterInstance1 = PhotonNetwork.Instantiate(monsterPrefab.name, position1, Quaternion.identity);
                Vector2 position2 = new Vector2(xCoords2, yCoords2);
                GameObject monsterInstance2 = PhotonNetwork.Instantiate(monsterPrefab.name, position2, Quaternion.identity);

                prefabInstancesList.Add(monsterInstance1);
                prefabInstancesList.Add(monsterInstance2);
            }


        }
    }

/*    void AddPrefabInstanceToList() {
        *//* monsterList = new MonsterList();
         monsterList.list = new List<Vector2>();*//*

        for (int i = 0; i < monsterCount; i++) {
            // Create a new instance of the prefab (not in the game world).
            GameObject prefabInstance = Instantiate(monsterPrefab);
            // Add the prefab instance to the list.
            prefabInstancesList.Add(prefabInstance);
            // Optionally, you can deactivate the prefab instance to keep it inactive.
            prefabInstance.SetActive(false);

        }


    }*/

    void DestroyMonster() {//+++
        photonView.RPC("RPC_DestroyMonster", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void RPC_DestroyMonster() { //++++
        // Code to destroy the monster on all players' clients

        if (photonView.IsMine) {
            PhotonNetwork.Destroy(gameObject);
        }

    }

/*    void OnJoinedRoom() { //+++++
        // Instantiate monsters for new player
        InstantiateExistingGameObjects();
    }*/

/*    void InstantiateExistingGameObjects() {//++++

        foreach (GameObject *//*or var*//* obj in prefabInstancesList) {
            // Instantiate the monster for the new player
            photonView.RPC("RPC_InstantiateMonster", RpcTarget.Others, obj.transform.position);
        }
    }

    [PunRPC]
    void RPC_InstantiateObject(Vector3 position) { //++++
        // Instantiate an object for the new player
        GameObject newObj = Instantiate(monsterPrefab, position, Quaternion.identity);
        // Transfer ownership to the new player
        newObj.GetPhotonView().TransferOwnership(PhotonNetwork.LocalPlayer);
    }*/
}

class MonsterList {
    public List<Vector2> list;
}
