using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWardrobe : MonoBehaviour
{
    [SerializeField] ItemContainer inventory;
    [SerializeField] GameObject _buttonPref;
    [SerializeField] Transform _buttonParent;

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
