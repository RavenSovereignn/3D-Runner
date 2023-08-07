using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static UnityEditor.Timeline.Actions.MenuPriority;
using Unity.VisualScripting;

public class ShopManager : MonoBehaviour
{
    [Header("UI refernces")]
    public itemShop[] shopItem;
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelSO;
    public PlayerStats playerStats;
    public Button[] purchaseButton;


    [Header("Customisation Points")]
    public Transform HatRootParent;
    public Transform NeckRootParent;
    public Transform FeetRootParent;

    public int buttonNumber;

    public List<itemShop> OwnedItems = new List<itemShop>();
    public List<HolderScript> EquippedItems = new List<HolderScript>();
    
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

    public void PurchaseItem(int buttonNumber)
    {
        if(playerStats.currency >= shopItem[buttonNumber].itemPriceCurrency)
        {
            playerStats.currencyRemove(shopItem[buttonNumber].itemPriceCurrency);
            shopPanelSO[buttonNumber].transform.GetChild(3).gameObject.SetActive(false);
            shopPanelSO[buttonNumber].transform.GetChild(4).gameObject.SetActive(true);
            OwnedItems.Add(shopItem[buttonNumber]);
           

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
            shopPanels[i].ItemID = shopItem[i].id;
        }
    }

    public void EquipItem(int buttonNumber)
    {
        Transform equipPoint;
        var item = shopItem[buttonNumber];

        switch (shopItem[buttonNumber].itemType)
        {
            case itemShop.ItemType.Hat:
                equipPoint = HatRootParent;
                break;
            case itemShop.ItemType.Neck:
                equipPoint = NeckRootParent;
                break;
            case itemShop.ItemType.Feet:
                equipPoint = FeetRootParent;
                break;
            default:
                equipPoint = HatRootParent;
                break;

        }
        SpawnItem(item, equipPoint);
    }

    public void SpawnItem(itemShop item, Transform playerEquipPoint)
    {
        //ward item holds all detail needed to spawn and position item
        itemShop shopItem = item;
        HolderScript equipped = null;
        foreach (HolderScript equippedItem in EquippedItems)
        {
            if ((int)equippedItem.ItemType == (int)item.itemType)
            {
                equipped = equippedItem;
            }
        }

        //remove equipped item and destroy it in scene
        if (equipped != null)
        {
            EquippedItems.Remove(equipped);
            Destroy(equipped.gameObject);
        }

        //cust item is the actual in scene customisation item
        GameObject custItem = Instantiate(item.itemPrefab, playerEquipPoint);
        HolderScript itemIdentifier = custItem.AddComponent<HolderScript>();
        itemIdentifier.itemInfo = item.itemInfo;

        //add item to equipped list
        itemIdentifier.ItemType = (ItemType)item.itemType;
        EquippedItems.Add(itemIdentifier);


        //set items pos, rot and scale
        custItem.transform.localPosition = item.mPos;
        custItem.transform.localRotation = Quaternion.Euler(item.mRot);
        custItem.transform.localScale = item.mScale;




    }
}
