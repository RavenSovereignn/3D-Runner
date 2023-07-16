using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "items/New Shop Item", order = 1)]
public class itemShop : ScriptableObject
{
    public string itemName;
    //Item description
    public string itemInfo;
    public int itemPriceCurrency;
    public int itemPriceGems;
}
