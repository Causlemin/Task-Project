using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController instance;
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject mainWardrobe;
    private float initialCoinAmount = 4000f;
    [SerializeField] float coinAmount;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("CoinAmount"))
        {
            PlayerPrefs.SetFloat("CoinAmount", initialCoinAmount);
            coinAmount = initialCoinAmount;
        }

        else
        {
            coinAmount = PlayerPrefs.GetFloat("CoinAmount");
        }

        GameManager.instance.coinText.text = coinAmount.ToString() + "$";
    }

    public void InventoryPanel()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
    }

    public void MainWardrobe()
    {
        mainWardrobe.SetActive(!mainWardrobe.activeInHierarchy);
    }

    public void SetCoinAmount(float f)
    {
        float newCoinAmount = coinAmount - f;
        PlayerPrefs.SetFloat("CoinAmount", newCoinAmount);
        coinAmount = newCoinAmount;
        GameManager.instance.coinText.text = newCoinAmount.ToString() + "$";
    }
}
