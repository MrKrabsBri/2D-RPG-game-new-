using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public Sprite emptyChest;
    public Sprite WindowAI;

    protected bool collected ;
public int coinAmount = 5;


    protected void OnCollect(){  // overridink is kito method , pvz collectable.
        collected = true;

        if (!collected){
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Gained" + coinAmount + "Coins");
        }
    }
}
