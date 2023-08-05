using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuController : MonoBehaviour
{
    public Animator playerAnimator;
    float delay = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RandomPeck", delay);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void BirdTouched()
    {
        playerAnimator.SetTrigger("Clicked");
        this.gameObject.GetComponent<PlayerMovement>().enabled = true;
        this.gameObject.GetComponent<PlayerMenuController>().enabled = false;
    }
    public void RandomPeck()
    {
        playerAnimator.SetTrigger("Peck");
    }
}
