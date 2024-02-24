using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinished : MonoBehaviour
{
    PlayerSeedsAndMoney playerUI;
    Grow growling;

    private void Start()
    {
        playerUI = FindObjectOfType<PlayerSeedsAndMoney>();
        growling = FindObjectOfType<Grow>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("Player coœ");
            if (this.gameObject.tag == "Lettuce")
            {
                playerUI.lettuceAmount += 4;
                playerUI.lettuceText.text = playerUI.lettuceAmount.ToString();
                Destroy(this.gameObject);
               
                
               
            }
            else if (this.gameObject.tag == "Tomato")
            {
                playerUI.tomatoAmount += 4;
                playerUI.tomatoText.text = playerUI.tomatoAmount.ToString();
                Destroy(this.gameObject);
                
                

            }
            else if (this.gameObject.tag == "Carrot")
            {
                playerUI.carrotAmount += 4;
                playerUI.carrotText.text = playerUI.carrotAmount.ToString();
                Destroy(this.gameObject);
             
                

            }
            else if (this.gameObject.tag == "Cucumber")
            {
                playerUI.cucumberAmount += 4;
                playerUI.cucumberText.text = playerUI.cucumberAmount.ToString();
                Destroy(this.gameObject);
                
                
            }
        }
    }
}
