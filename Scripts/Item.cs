using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public bool stackable = true;
    public Sprite icon;
    public float price;
    public bool equipped;
    public Category category;
}

public enum Category
{
    pants,
    shirts,
    shoes
}
