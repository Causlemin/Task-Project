using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//Refeference for Item Container class to generate List
public class ItemSlot
{
    public Item item;
    public int count;
}

//For creatable scriptable objects inside the editor 
[CreateAssetMenu(menuName = "Data/Item Container")]
//This class keeps the items
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    //Add item to Item Container
    public void AddItem(Item item, int count = 1)
    {
        //Add stackable item
        if (item.stackable)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            InventoryController.instance.SetCoinAmount(item.price);
            //null check, if item is not null add 1 more
            if(itemSlot != null)
            {
                itemSlot.count += count;
                InventoryPanel.instance.SetIfExist(itemSlot);
            }

            else
            {
                itemSlot = slots.Find(x => x.item == null);

                if(itemSlot != null)
                {
                    itemSlot.item = item;
                    itemSlot.count = count;
                    InventoryPanel.instance.ShowPurchasedItem(itemSlot);
                }
            }
        }

        else
        {
            // add non stackable item to item container
            ItemSlot itemSlot = slots.Find(x => x.item == null);

            //null check
            if(itemSlot != null)
            {
                itemSlot.item = item;
            }
        }
    }
}
