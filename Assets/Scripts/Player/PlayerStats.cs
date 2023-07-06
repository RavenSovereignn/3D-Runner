using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private PlayerMovement movement;

    public int p_Score;
    public int currency;


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
    }

    public void currencyAdd( int amount)
    {
        currency += amount;
    }
}
