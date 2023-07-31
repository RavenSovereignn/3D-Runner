using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ShopManager : MonoBehaviour
{
    public itemShop[] shopItem;
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelSO;
    public PlayerStats playerStats;
    public Button[] purchaseButton;


    public void CheckPurchaseableCurrency()
    {
        for(int i = 0;i < shopItem.Length;i++)
        {
           if(playerStats.currency >= shopItem[i].itemPriceCurrency)
           {
                purchaseButton[i].interactable = true;
           }
           else
           {
                purchaseButton[i].interactable = false;
           }
        }
    }
    public void LoadShop()
    {
        for (int i = 0; i < shopItem.Length; i++)
        {
            shopPanelSO[i].SetActive(true);
        }
        LoadShopPanels();
        CheckPurchaseableCurrency();
    }

    public void PurchaseItem(int btnNo)
    {
        if(playerStats.currency >= shopItem[btnNo].itemPriceCurrency)
        {
            playerStats.currencyRemove(shopItem[btnNo].itemPriceCurrency);
            shopPanelSO[btnNo].transform.GetChild(3).gameObject.SetActive(false);
            shopPanelSO[btnNo].transform.GetChild(4).gameObject.SetActive(true);

            
            CheckPurchaseableCurrency();


        }
    }
    
    public void LoadShopPanels()
    {
        for (int i = 0; i < shopItem.Length; i++)
        {
            shopPanels[i].itemNameText.text = shopItem[i].itemName;
            shopPanels[i].itemSpriteImage.sprite = shopItem[i].itemSprite;
            shopPanels[i].itemPriceCurrencyText.text = shopItem[i].itemPriceCurrency.ToString();
            shopPanels[i].itemPriceGemsText.text = shopItem[i].itemPriceGems.ToString();
        }
    }
}
