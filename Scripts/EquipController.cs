using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class EquipController : MonoBehaviour
{
    public static EquipController instance;

    public GameObject[] pants;
    public GameObject[] shirts;
    public GameObject[] shoes;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SetStart();
    }

    public void SetPant(Item item)
    {
        foreach (var i in pants)
        {
            Outfit of = i.GetComponent<Outfit>();

            if (of.item == item)
            {
                of.item.equipped = true;
                i.SetActive(true);
            }
            else
            {
                of.item.equipped = false;
                i.SetActive(false);
            }
        }
    }

    public void SetShirt(Item item)
    {
        foreach (var i in shirts)
        {
            Outfit of = i.GetComponent<Outfit>();

            if (of.item == item)
            {
                of.item.equipped = true;
                i.SetActive(true);
            }
            else
            {
                of.item.equipped = false;
                i.SetActive(false);
            }
        }
    }

    public void SetShoe(Item item)
    {
        foreach (var i in shoes)
        {
            Outfit of = i.GetComponent<Outfit>();

            if (of.item == item)
            {
                of.item.equipped = true;
                i.SetActive(true);
            }
            else
            {
                of.item.equipped = false;
                i.SetActive(false);
            }
        }
    }

    void SetStart()
    {
        foreach (var i in pants)
        {
            Outfit of = i.GetComponent<Outfit>();

            if (of.item.equipped)
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }
        }

        foreach (var i in shirts)
        {
            Outfit of = i.GetComponent<Outfit>();

            if (of.item.equipped)
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }
        }

        foreach (var i in shoes)
        {
            Outfit of = i.GetComponent<Outfit>();

            if (of.item.equipped)
            {
                i.SetActive(true);
            }
            else
            {
                i.SetActive(false);
            }
        }
    }
}
