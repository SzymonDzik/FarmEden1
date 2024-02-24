using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSeedsAndMoney : MonoBehaviour
{

    public ShopActivation shop;
    public Text lettuceText;
    public Text tomatoText;
    public Text carrotText;
    public Text cucumberText;

    public int lettuceAmount = 0;
    public int tomatoAmount = 0;
    public int carrotAmount = 0;
    public int cucumberAmount = 0;

    public int money = 2000;

    public int lettucePrice = 25;
    public int tomatoPrice = 100;
    public int carrotPrice = 400;
    public int cucumberPrice = 800;


    public Text moneyText;
    public Text lettucePriceText;
    public Text tomatoPriceText;
    public Text carrotPriceText;
    public Text cucumberPriceText;


    private void Start()
    {
        shop = FindObjectOfType<ShopActivation>();
  
        moneyText.text = money.ToString();
        lettucePriceText.text = lettucePrice.ToString();
        tomatoPriceText.text = tomatoPrice.ToString();
        carrotPriceText.text = carrotPrice.ToString();
        cucumberPriceText.text = cucumberPrice.ToString();
    }

    public void AddLettuce()
    {
        if(money >= lettucePrice)
        {
            lettuceAmount++;
            money -= lettucePrice;
            moneyText.text = money.ToString();
        }
        
        lettuceText.text = lettuceAmount.ToString();
    }
    public void AddTomato()
    {
        if (money >= tomatoPrice)
        {
            tomatoAmount++;
            money -= tomatoPrice;
            moneyText.text = money.ToString();
        }
        
        tomatoText.text = tomatoAmount.ToString();
    }
    public void AddCarrot()
    {
        if (money >= carrotPrice)
        {
            carrotAmount++;
            money -= carrotPrice;
            moneyText.text = money.ToString();
        }
        
        carrotText.text = carrotAmount.ToString();
    }
    public void AddCucumber()
    {
        if (money >= cucumberPrice)
        {
            cucumberAmount++;
            money -= cucumberPrice;
            moneyText.text = money.ToString();
        }
        
        cucumberText.text = cucumberAmount.ToString();
    }


    public void SellLetttuce()
    {
        if (shop.isShopActive && lettuceAmount > 0)
        {
            lettuceAmount--;
            money += lettucePrice;
        }
        lettuceText.text = lettuceAmount.ToString();
        moneyText.text = money.ToString();

    }

    public void SellTomato()
    {
        if (shop.isShopActive && tomatoAmount > 0)
        {
            tomatoAmount--;
            money += tomatoPrice;       
        }
        tomatoText.text = tomatoAmount.ToString();
        moneyText.text = money.ToString();

    }

    public void SellCarrot()
    {
        if (shop.isShopActive && carrotAmount > 0)
        {
            carrotAmount--;
            money += carrotPrice;
        }
        carrotText.text = carrotAmount.ToString();
        moneyText.text = money.ToString();
    }
    public void SellCucumber()
    {
        if (shop.isShopActive && cucumberAmount > 0)
        {
            cucumberAmount--;
            money += cucumberPrice;                     
        }
        cucumberText.text = carrotAmount.ToString();
        moneyText.text = money.ToString();

    }

    public void LettucePlant()
    {
        lettuceAmount--;
        lettuceText.text = lettuceAmount.ToString();
    }

    public void TomatoPlant()
    {
        tomatoAmount--;
        tomatoText.text = tomatoAmount.ToString();
    }
    public void CarrotPlant()
    {
        carrotAmount--;
        carrotText.text = carrotAmount.ToString();
    }
    public void CucumberPlant()
    {
        cucumberAmount--;
        cucumberText.text = cucumberAmount.ToString();
    }
}
