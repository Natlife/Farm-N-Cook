using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Collectable[] collectableItem;
    private Dictionary<CollectableType,Collectable> itemDic = new Dictionary<CollectableType,Collectable>();
    private void Awake()
    {
        foreach (Collectable collectable in collectableItem)
        {
            addItem(collectable);
        }
    }

    //add item to the dictionary
    private void addItem(Collectable item)
    {
        if(!itemDic.ContainsKey(item.itemType))
        {
            itemDic.Add(item.itemType, item);
        }
    }

    //fucntion get the value of dictionary from type
    public Collectable getItemByType(CollectableType type)
    {
        if (itemDic.ContainsKey(type))
        {
            return itemDic[type];

        }
        return null;
    }
}
