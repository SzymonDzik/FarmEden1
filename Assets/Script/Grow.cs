using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class Grow : MonoBehaviour
{
    [SerializeField] public float Growth=0;
    [SerializeField] public float GrowthTime = 10f;
    private bool watered = false;

    public bool Watered { get { return watered; } set { watered = value; } }
    
    private Land.LandStatus landStatus = Land.LandStatus.Soil;
   

    PlayerSeedsAndMoney playerUI;

    Land land;
    private GameObject newPrefab;
    public GameObject lettucePrefab;
    public GameObject tomatoPrefab;
    public GameObject cucumberPrefab;
    public GameObject carrotPrefab;
    private void Awake()
    {
        land = FindObjectOfType<Land>();
        playerUI = FindObjectOfType<PlayerSeedsAndMoney>();
        watered = false;
       
        GrowthTime = 10f;

    }
    public void podrosnij()
    {
        Debug.Log(Land.LandStatus.Watered);
        if (Land.LandStatus.Watered.ToString() == "Watered") 
        {
            
            if (Growth / GrowthTime >= 1)
            {
                
                ReadyToHarvest();
               
            }
            else
            {
                
                Growth += 1;
                transform.localScale = 1.5f * new Vector3(0.4f + Growth / GrowthTime, 0.4f +  Growth / GrowthTime, 0.4f + Growth / GrowthTime);
            }          
            
        }
    }

    private void ReadyToHarvest()
    {
        Debug.Log(this.gameObject.tag);
        if (this.gameObject.tag == "Lettuce")
        {
            
            newPrefab = Instantiate(lettucePrefab, transform.position + new Vector3(0, 0.2f, 0f), Quaternion.identity);
            newPrefab.AddComponent<OnFinished>();
            newPrefab.tag = "Lettuce";
            this.gameObject.tag = "Delete";
            this.gameObject.SetActive(false);

            
            Growth = 0;
            Debug.Log(this.gameObject.tag);
        }

        else if (this.gameObject.tag == "Tomato")
        {
            newPrefab = Instantiate(tomatoPrefab, transform.position + new Vector3(0, 0.2f, 0f), Quaternion.identity);
            newPrefab.AddComponent<OnFinished>();
            newPrefab.tag = "Tomato";
            this.gameObject.tag = "Delete";
            this.gameObject.SetActive(false);
           
            Growth = 0;
            Debug.Log(this.gameObject.tag);
        }
        else if (this.gameObject.tag == "Carrot")
        {
            newPrefab = Instantiate(carrotPrefab, transform.position + new Vector3(0, 0.2f, 0f), Quaternion.identity);
            newPrefab.AddComponent<OnFinished>();
            newPrefab.tag = "Carrot";
            this.gameObject.tag = "Delete";
            this.gameObject.SetActive(false);
            Growth = 0;
            Debug.Log(this.gameObject.tag);
        }
        else if (this.gameObject.tag == "Cucumber")
        {
            newPrefab = Instantiate(cucumberPrefab, transform.position + new Vector3(0, 0.2f, 0f), Quaternion.identity);
            newPrefab.AddComponent<OnFinished>();
            newPrefab.tag = "Cucumber";
            this.gameObject.tag = "Delete";
            this.gameObject.SetActive(false);
            
            Growth = 0;
            Debug.Log(this.gameObject.tag);
        }

        this.gameObject.tag = "Delete";
        Debug.Log(this.gameObject.tag);
    }

   

}
