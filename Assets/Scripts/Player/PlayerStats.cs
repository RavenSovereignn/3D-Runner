using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    private PlayerMovement movement;

    public int p_Score;
    public int currency;
    public int gold;
    public TextMeshProUGUI currencyUI;
    public TextMeshProUGUI goldUI;
    public ScoreManager scoreManager;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }
    public void Update()
    {
         if(movement.moveSpeed <= 5)
        {
            Debug.Log("U lost");
            scoreManager.EndScore();
        }
        currencyUI.text = currency.ToString();
        goldUI.text = gold.ToString();
         if(Input.GetKeyDown(KeyCode.J))
        {
            currencyAdd(10000);
        }
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
