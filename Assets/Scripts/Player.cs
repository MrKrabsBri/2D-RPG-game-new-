using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Photon.Pun;
using UnityEngine.ProBuilder;
using Photon.Pun.UtilityScripts;

public class Player : MonoBehaviourPun, IPunObservable {

    //private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    //private RaycastHit2D hit;
    private float moveSpeed = 5f;

    private bool isMoving;
    public Animator animator;
    private Vector3 initialScale; // keeping size from Scale
    public PhotonView view;
    //PhotonTransformView photonTransferView;
    //private bool isFacingRight;
    public SpriteRenderer sr;
    PhotonAnimatorView photonAnimatorView;
    //private bool moveLeft = true;
    private Vector3 smoothMove;
   // private GameObject sceneCamera;
    public GameObject playerCamera;
    //public Camera cam;



    // Start is called before the first frame update
    private void Start() {

        PhotonNetwork.SendRate = 20;
        PhotonNetwork.SerializationRate = 15;

        //isFacingRight = true;


       // boxCollider = GetComponent<BoxCollider2D>();
        view = GetComponent<PhotonView>();
        sr = GetComponent<SpriteRenderer>();

        if (photonView.IsMine) {
           // sceneCamera = GameObject.Find("Main Camera");
           // sceneCamera.SetActive(false);
            playerCamera.SetActive(true);
        }
        else {
            //sceneCamera.SetActive(true);
            playerCamera.SetActive(false);
        }


    }

    // Update is called once per frame
    private void FixedUpdate() {
        if (photonView.IsMine) {

            ProcessInputs();
        }
        else {
            SmoothMovement();
        }


    }

    private void ProcessInputs() {
        /* var move = new Vector3(Input.GetAxis("Horizontal"), transform.position.y*//*0*//*);
         transform.position += move * moveSpeed * Time.deltaTime;*/ // FROM photon GUIDE
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveDelta = new Vector3(x, y, 0).normalized;
        transform.position += (moveDelta * moveSpeed * Time.deltaTime);

        if (moveDelta.x > 0) {
            sr.flipX = false;
            view.RPC("OnDirectionChange_RIGHT", RpcTarget.Others);
           // Debug.Log("desine");
        }
        else if (moveDelta.x <0) {
            sr.flipX = true;
            view.RPC("OnDirectionChange_LEFT", RpcTarget.Others);
           // Debug.Log("kaire");
        }
    }

    private void SmoothMovement() {
        transform.position = Vector3.Lerp(transform.position, smoothMove, Time.deltaTime * 10);
    }


    [PunRPC]
    void OnDirectionChange_LEFT() {
        sr.flipX = true;
    }
    [PunRPC]
    void OnDirectionChange_RIGHT() {
        sr.flipX = false;
    }

    [PunRPC]
    private void RPCFlipSprite(bool flipValue) {
        // Update the flipX value for remote players
        sr.flipX = flipValue;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        // Implement this method for IPunObservable
        if (stream.IsWriting) {
            stream.SendNext(transform.position);
        }
        else if (stream.IsReading) {
            smoothMove = (Vector3)stream.ReceiveNext();
        }

    }


}