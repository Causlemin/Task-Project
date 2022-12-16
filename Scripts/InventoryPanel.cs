using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public static InventoryPanel instance;
    [SerializeField] ItemContainer inventory;
    [SerializeField] GameObject _buttonPref;
    [SerializeField] Transform _buttonParent;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        Show();
    }

    private void OnDisable()
    {
        CleanWardrobe();
    }

    private void Show()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            GameObject btn = Instantiate(_buttonPref, _buttonParent);
            InventoryButton _btn = btn.GetComponent<InventoryButton>();

            if (inventory.slots[i].item == null)
            {
                _btn.Clean();
            }

            else
            {
                _btn.Set(inventory.slots[i]);
            }
        }
    }

    public void ShowPurchasedItem(ItemSlot slot)
    {
        GameObject btn = Instantiate(_buttonPref, _buttonParent);
        InventoryButton _btn = btn.GetComponent<InventoryButton>();
        _btn.Set(slot);
    }

    public void SetIfExist(ItemSlot slot)
    {
        for (int i = 0; i < _buttonParent.transform.childCount; i++)
        {
            InventoryButton _btn = _buttonParent.transform.GetChild(i).GetComponent<InventoryButton>();

            if (_btn.itemSlot == slot)
            {
                _btn.SetIfExist(slot);

                break;
            }
        }
    }

    private void CleanWardrobe()
    {
        GameObject[] childrenOfMaster = new GameObject[_buttonParent.transform.childCount];

        for (int i = 0; i < childrenOfMaster.Length; i++)
        {
            childrenOfMaster[i] = _buttonParent.transform.GetChild(i).gameObject;
        }
        _buttonParent.transform.DetachChildren();
        foreach (GameObject go in childrenOfMaster)
        {
            Destroy(go);
        }
    }
}
