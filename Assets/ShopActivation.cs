using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopActivation : MonoBehaviour
{
    public GameObject shopUI;
    public bool isShopActive = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            shopUI.SetActive(true);
            isShopActive = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            shopUI.SetActive(false);
            isShopActive = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

   
}
