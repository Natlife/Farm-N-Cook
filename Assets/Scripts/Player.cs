using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    private void Awake()
    {
        inventory = new Inventory(9);//amount of slot
    }
    public void dropItem(Collectable item)
    {
        Vector3 spawnLocate= transform.position;//set the location of item when drop
        //make sure the item is not same with player so that the item will not be auto pick up again
        Vector3 spawnItem = new Vector3(1, -1, 0f).normalized;

        Collectable droppedItem=Instantiate(item,spawnLocate+spawnItem,Quaternion.identity);
        droppedItem.icon=item.icon;
        if(droppedItem.icon==null)
        {
            Debug.Log("DM");
        }
    }
}
