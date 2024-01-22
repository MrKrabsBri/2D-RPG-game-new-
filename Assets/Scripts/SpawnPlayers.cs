
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject monsterPrefab;

    //for random spawn
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start() {
        SpawnPlayer();
    }

    public void SpawnPlayer() {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        // be sito kiekvienas savo client matytu tik savo player,
        // su situo visi playeriai matysis visose game versijose.
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        //PhotonNetwork.Instantiate(monsterPrefab.name, randomPosition, Quaternion.identity);
    }

}
