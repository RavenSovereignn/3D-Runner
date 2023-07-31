using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "shopMenu", menuName = "items/New Shop Item", order = 1)]
public class itemShop : ScriptableObject
{
    public string itemName;
    public int id;
    //Item description
    public Sprite itemSprite;
    public int itemPriceCurrency;
    public int itemPriceGems;
}
