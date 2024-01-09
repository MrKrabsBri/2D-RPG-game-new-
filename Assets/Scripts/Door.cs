using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Collidable {

    public Sprite openedDoor;

    private void OnTriggerEnter2D(Collider2D other) {
        OnCollide(other);

    }

    protected override void OnCollide(Collider2D coll) {
        Debug.Log("collided with " + coll.name + "child method");
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = openedDoor; //chestscript.emptychest
    }


}
