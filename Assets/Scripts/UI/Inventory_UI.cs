using System.Collections;
using System.Collections.Generic;
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

    //SetUp function:
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
} 
