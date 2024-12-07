using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    //SetItem
    //SetEmpty

    public Image imgIcon;
    public TextMeshProUGUI quantityText;

    //Set Item function:
    //pick the Slot object in Inventory class and check if it !=null ----> the slot have item inside
        //setup for the item icon and quanity text
    public void setItem(Inventory.slot slot)
    {
        if(slot != null)
        {
            imgIcon.sprite = slot.icon;
            imgIcon.color = new Color(1, 1, 1, 1);//make the icon visible
            quantityText.text= slot.count.ToString();
        }
    }
    //Set Empty function:
    //set the icon to null and quantity text to 0 when the slot is empty
    public void setEmpty()
    {
        imgIcon.sprite= null;
        imgIcon.color = new Color(1, 1, 1, 0);//make the white square of null icon not display
        quantityText.text = "";
    }

}
