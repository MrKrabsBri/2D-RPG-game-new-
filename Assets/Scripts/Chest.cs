using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    private BoxCollider2D boxCollider;
    public ContactFilter2D filter;
    public Sprite emptyChest;
    //public Sprite WindowAI;

    protected bool collected;
    public int coinAmount = 5;

    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update() {
        //  boxCollider.OverlapCollider(filter,null);


        void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                // if (other.gameObject.tag== "Player"){
                openChest();
                Debug.Log(other.name);
                //OnCollect();
            }
        }
    }


    public virtual void OnCollide(Collider2D coll) {
        Debug.Log(coll.name);
    }



    void openChest() {

        //Chest chestScript = GetComponent<Chest>();

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = emptyChest; //chestscript.emptychest

    }


    public void OnCollect() {  // overridink is kito method , pvz collectable.
        collected = true;

        if (!collected) {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Gained" + coinAmount + "Coins");
        }
    }
}
