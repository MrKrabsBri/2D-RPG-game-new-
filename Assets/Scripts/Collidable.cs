using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Collidable;//pridek prie kitu scripts kurie sita naudos



public class Collidable : MonoBehaviour {

    private BoxCollider2D boxCollider;

    public ContactFilter2D filter;

    private Collider2D[] collisions = new Collider2D[10];

    /*    protected void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                // if (other.gameObject.tag== "Player"){

                Debug.Log(other.name);
                //OnCollect();
            }
        }*/


    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update() {
        //Collision work, tikrina collisions visuose layers.
        boxCollider.OverlapCollider(filter, collisions);

        for (int i = 0; i < collisions.Length; i++) {
            if (collisions[i] == null)
                continue;

            // one way to do it: if(this.tag == "NPC_0")


            OnCollide(collisions[i]);
            //Destroy(collisions[i].gameObject);

            // the array is not cleaned up, so we do it ourself
            collisions[i] = null;
        }

    }

/*    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("collision");
        if (collision.collider.CompareTag("Player")) {
            Destroy(collision.gameObject);
        }
    }*/

    protected virtual void OnCollide(Collider2D coll) {
        Debug.Log("collided with " + coll.name);
        if (coll.CompareTag("Monster")) {
            Destroy(coll.gameObject);
        }
    }
}

