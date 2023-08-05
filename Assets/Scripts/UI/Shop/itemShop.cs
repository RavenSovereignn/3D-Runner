using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "shopMenu", menuName = "items/New Shop Item", order = 1)]
public class itemShop : ScriptableObject
{
    //Base Item details
    public string itemName;
    public int id;
    public Sprite itemSprite;
    public int itemPriceCurrency;
    public int itemPriceGems;
    public GameObject itemPrefab;

    //where on the Crow the item should go
    [Header("Positioning")]
    public Vector3 mPos;
    public Vector3 mRot;
    public Vector3 mScale;
}
