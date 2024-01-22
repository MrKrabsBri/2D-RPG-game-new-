using Photon.Pun;
using UnityEngine;

public class Automove : MonoBehaviour
{
    private bool moveLeft = true;
    private float timer = 0f;
    private float moveSpeed = 2f; // Adjust the speed as needed
    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate() {
        // Move to the left for 3 second
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

/*    private void OnTriggerEnter2D(Collider2D otherCollider) {
        // Check if the colliding GameObject is the player
        Debug.Log("triggeris");
        if (otherCollider.CompareTag("Player")) {
            // Assuming the player has a script that handles health (replace "PlayerHealth" with your actual script name)

            // Destroy the monster GameObject
            OnCollide(otherCollider);
            Debug.Log("destroying");
            Destroy(gameObject);
        }
    }

    protected virtual void OnCollide(Collider2D coll) {
        Debug.Log("collided with " + coll.name);
    }*/



}
