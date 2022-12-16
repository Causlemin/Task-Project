using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public ItemContainer inventoryContainer;
    public Text coinText;
    public DialogSystem dialogSystem;

    private void Awake()
    {
        instance = this;
    }
}
