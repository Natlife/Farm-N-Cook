using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //All function:
    //adding the object to the player's inventory when walk into the object
    //Deleting the object in the inventory
    public CollectableType itemType;
    public Sprite icon;

    //OnTriigerEnter function:
    //when object walk into the trigger and have collider, the function will be called
    //identify the player walk into the trigger
        //declare the object Player then get value from collision.
            //collision return value then player walk into the trigger -->number of seed +1 and delete object in the world map
            //collision return null then player dont walk into trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {//Call when object walk into the trigger and have collider
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            player.inventory.Add(this);
            Destroy(this.gameObject);
        }
        

    }
}
public enum CollectableType
{//Manage the type of item
    NONE,SEED,PRODUCT,EQUIPMENT
}
