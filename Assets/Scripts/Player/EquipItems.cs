using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItems : MonoBehaviour
{
    #region singleton
    public static EquipItems Instance;
    
    void Awake()
    {
        Instance = this;
    }
    #endregion

    itemShop[] currentItems;

     public void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(itemShop.itemSlot)).Length;
        currentItems = new itemShop[numSlots];
    }

    public void Equip (itemShop newItem)
    {
        int slotIndex = (int)newItem.equipItemslot;

        currentItems[slotIndex] = newItem;
    }
}
