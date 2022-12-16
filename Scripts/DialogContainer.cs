using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Dialog/Dialog")]
public class DialogContainer : ScriptableObject
{
    public List<string> line;
    public Shopkeeper shopKeeper;
}
