using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Inventory
{

    //Setup slot object

    //Slot function
    //check the item in the slot, the number of it and the max amount of item

    [System.Serializable]
    public class slot
    {
        public CollectableType itemType;
        public int count;
        public int maxAmount;
        public Sprite icon;
        public slot()
        {
            itemType=CollectableType.NONE;
            count=0;
            maxAmount=10;
        }
        public bool canAdd()
        {
            if (count < maxAmount)
            {
                return true;
            }
            return false;
        }
        public void addItem(Collectable item)
        {
            this.itemType=item.itemType;
            this.icon= item.icon;
            count++;
        }
        public void removeItem()
        {
            
            if (count > 0)
            {
                count--;
                if (count == 0)
                {
                    this.itemType = CollectableType.NONE;
                    this.icon = null;
                }
            }
        }
    }
    public List<slot> slotList=new List<slot>();//create the way to store the information


    //Constructor is called to add the slot index into the inventory
    public Inventory(int amountOfSlots)
    {
        for (int i = 0; i < amountOfSlots; i++)
        {
            slot index = new slot();
            slotList.Add(index);
        }
    }

    //Add function:
    //searching the inventory for same type with the new item trying to add into
    public void Add(Collectable item)
    {   
        //if == typeToAdd
         foreach(slot slot in slotList)
        {
            if (slot.itemType == item.itemType && slot.canAdd())
            {
                slot.addItem(item);
                return;
            }
        }
         //if itemType= none --> auto add to the slot
        foreach (slot slot in slotList)
        {
            if (slot.itemType == CollectableType.NONE)
            {
                slot.addItem(item);
                return;
            }
        }
    }
    public void Remove(int index)
    {
        slotList[index].removeItem();
    }

}
