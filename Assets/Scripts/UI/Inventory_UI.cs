using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<Slot_UI> slotList=new List<Slot_UI>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            toggleInventory();
        }
    }

    public void toggleInventory()
    {
        if (inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(false); 
        }
        else
        {
            inventoryPanel.SetActive(true);
            setUp();
        }
    }

    //ReFresh function:
    //Check for the change when the InventoryUI active
        //if have item in slot, call the setItem method with slotList element
        //else: call setEmpty method to set default slot icon and text  
    public void setUp()
    {
        if(slotList.Count==player.inventory.slotList.Count) //check the same amount of slot between inventory and inventory_UI
        {
            for(int i = 0; i<slotList.Count; i++)
            {
                if(player.inventory.slotList[i].itemType != CollectableType.NONE)
                {
                    slotList[i].setItem(player.inventory.slotList[i]);
                }
                else
                {
                    slotList[i].setEmpty();
                }
            }
        }
    }
    public void Remove(int slotID)
    {
        Collectable itemNeedToDrop= GameManager.instance.itemManager.getItemByType(player.inventory.slotList[slotID].itemType);  //call the get item type function in the itemManager
        if(itemNeedToDrop != null)
        {
            player.dropItem(itemNeedToDrop);
            player.inventory.Remove(slotID);
            setUp();
        }
        else
        {
            Debug.Log("sai roi dm");
        }
    }
} 
