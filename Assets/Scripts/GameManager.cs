using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ItemManager itemManager;
    //check the instance is only
    //if not ----> delete one of the intances
    private void Awake()
    {
        if(instance != null && instance!=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);//make sure the game manger never be destroy by loading new scenes - follow until we quit
        itemManager = GetComponent<ItemManager>();//access through game manager
    }
}
