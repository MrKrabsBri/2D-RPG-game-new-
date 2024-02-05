using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private int[] inventorySlots = new int[28] ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        //OnCollide(other);
    }

/*    protected override void OnCollide(Collider2D coll) {
        Debug.Log("In " + coll.name + "child method");
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = openedDoor; //chestscript.emptychest
    }*/
}
