using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text amount;
    int myIndex;
    public Item _item;
    int count = 1;
    public ItemSlot itemSlot;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot slot)
    {
        itemSlot = slot;
        icon.sprite = slot.item.icon;
        _item = slot.item;
        
        if (slot.item.stackable)
        {
            amount.text = "Wear " + slot.count.ToString();
        }
    }

    public void SetIfExist(ItemSlot slot)
    {
        amount.text = "Wear " + slot.count.ToString();
    }

    public void Clean()
    {
        if(gameObject != null)
        Destroy(gameObject);
    }

    public void Buy()
    {
        if (GameManager.instance.inventoryContainer != null)
        {
            GameManager.instance.inventoryContainer.AddItem(_item, count);
        }

        else
        {
            Debug.LogWarning("No Inventory Container!");
        }
    }

    public void Equip()
    {
        if(_item.category == Category.pants) EquipController.instance.SetPant(_item);
        if (_item.category == Category.shirts) EquipController.instance.SetShirt(_item);
        if (_item.category == Category.shoes) EquipController.instance.SetShoe(_item);
    }
}
