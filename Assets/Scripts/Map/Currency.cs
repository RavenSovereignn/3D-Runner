using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    private PlayerStats playerStats;
    public int currencyWorth;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerStats.currencyAdd(currencyWorth);
            Destroy(gameObject);
        }
        
    }
}
