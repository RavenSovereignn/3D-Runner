using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    private PlayerMovement movement;

    public int p_Score;
    public int currency;
    public int gold;
    public TextMeshProUGUI currencyUI;
    public TextMeshProUGUI goldUI;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }
    public void Update()
    {
         if(movement.moveSpeed <= 5)
        {
            Debug.Log("U lost");
        }
        currencyUI.text = currency.ToString();
        goldUI.text = gold.ToString();
         
    }

    public void currencyAdd(int amount)
    {
        currency += amount;
    }
    public void currencyRemove(int amount)
    {
        currency -= amount;
    }
    public void goldAdd(int amount)
    {
        gold += amount;
    }
    public void goldRemove(int amount)
    {
        gold -= amount;
    }
}
