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

    void Update() {
        // Move to the left for 1 second
        if (moveLeft) {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            timer += Time.deltaTime;

            if (timer >= 1f) {
                moveLeft = false;
                timer = 0f;
            }
        }
        // Move to the right for 1 second
        else {


            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            timer += Time.deltaTime;

            if (timer >= 1f) {
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





}
