using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Photon.Pun;


public class Moving : MonoBehaviour {

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private float moveSpeed = 3.5f;
    public float playerSize = 6f;
    private bool isMoving;
    public Animator animator;
    private Vector3 initialScale; // keeping size from Scale
    PhotonView view;
    PhotonTransformView photonTransferView;
    private bool isFacingRight;
    private SpriteRenderer spriteRenderer;
    PhotonAnimatorView photonAnimatorView;

    // Start is called before the first frame update
    private void Start() {
        isFacingRight = true;
        boxCollider = GetComponent<BoxCollider2D>();
        view = GetComponent<PhotonView>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    private void FixedUpdate() {

        if (view.IsMine) {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            moveDelta = new Vector3(x, y, 0).normalized;
            //moveDelta.normalize(); // to prevent faster diagonal movement.
            isMoving = moveDelta.magnitude > Mathf.Epsilon;

            if (isMoving) {
                animator.SetBool("IsMoving", true);
                if (!isFacingRight && moveDelta.x > 0) {
                    Flip();
                }
                else if (isFacingRight && moveDelta.x < 0) {
                    Flip();
                }
                /*                if (!isFacingRight && moveDelta.x > 0) {
                                    spriteRenderer.flipX = isFacingRight;
                                }
                                else if (isFacingRight && moveDelta.x < 0) {
                                    spriteRenderer.flipX = !isFacingRight;

                                }*/
                else {
                    animator.SetBool("IsMoving", false);
                }


                transform.Translate(moveDelta * moveSpeed * Time.deltaTime);


            }
        }

    }

    private void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
