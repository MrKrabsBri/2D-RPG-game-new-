using Photon.Pun;
using UnityEngine;



public class Automove : MonoBehaviourPun, IPunObservable {
    private bool moveLeft = true;
    private float timer = 0f;
    private float moveSpeed = 3f; // Adjust the speed as needed
    private SpriteRenderer spriteRenderer;

    private Vector3 smoothMove;
    private Vector3 networkPosition;
    private Quaternion networkRotation;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate() {
        // Move to the left for 3 second
        if (photonView.IsMine) {
            if (moveLeft) {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                timer += Time.deltaTime;

                if (timer >= 3f) {
                    moveLeft = false;
                    timer = 0f;
                }
            }
            // Move to the right for 3 second
            else {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                timer += Time.deltaTime;

                if (timer >= 3f) {
                    moveLeft = true;
                    timer = 0f;
                }

            }
            if (!moveLeft) {
                spriteRenderer.flipX = true;
            }
            else {
                spriteRenderer.flipX = false;
            }
        }
        else {

            // Smoothly interpolate towards the target position and rotation
            transform.position = Vector3.Lerp(transform.position, networkPosition, Time.deltaTime * 10);
            transform.rotation = Quaternion.Lerp(transform.rotation, networkRotation, Time.deltaTime * 10);

        }
        /* else {
             transform.position = Vector3.Lerp(transform.position, networkPosition, Time.deltaTime * 10);
             transform.rotation = Quaternion.Lerp(transform.rotation, networkRotation, Time.deltaTime * 10);
         }*/
        /*       else {
                    SmoothMovement();
                }*/

    }

    private void SmoothMovement() {
        transform.position = Vector3.Lerp(transform.position, smoothMove, Time.deltaTime * 10);
    }


    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.IsWriting) {
            // This is the master client; send the position and rotation
            stream.SendNext(new Vector2(transform.position.x, transform.position.y));
            stream.SendNext(transform.rotation.z); // Send only the z-axis rotation for 2D
        }
        else if (stream.IsReading) {
            // This is the remote client; receive the position and rotation
            Vector2 receivedPosition = (Vector2)stream.ReceiveNext();
            float receivedRotationZ = (float)stream.ReceiveNext();

            // Use the received data to update the object's state++++
            /*          transform.position = new Vector3(receivedPosition.x, receivedPosition.y, transform.position.z);
                        transform.rotation = Quaternion.Euler(0, 0, receivedRotationZ);*/
            //smoothMove = (Vector3)stream.ReceiveNext();

            // Use Lerp for smoother movement
            float lerpFactor = 0.1f; // Adjust this value based on desired smoothness

            transform.position = Vector3.Lerp(transform.position, new Vector3(receivedPosition.x, receivedPosition.y, transform.position.z), lerpFactor);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, receivedRotationZ), lerpFactor);
        }

    }
    // photonView.RPC("UpdateMonsterPosition", RpcTarget.AllBuffered, position, rotation);

}


