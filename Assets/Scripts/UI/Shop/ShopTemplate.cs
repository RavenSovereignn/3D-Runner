using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopTemplate : MonoBehaviour
{
    public TMP_Text itemNameText;
    public Image itemSpriteImage;
    public TMP_Text itemPriceCurrencyText;
    public TMP_Text itemPriceGemsText;

    private void Awake()
    {
       itemSpriteImage = GetComponent<Image>();
    }


}
