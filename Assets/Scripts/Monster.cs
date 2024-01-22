using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviourPun
{
    public GameObject npcPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(npcPrefab.name, transform.position, transform.rotation);
        }
    }


}
