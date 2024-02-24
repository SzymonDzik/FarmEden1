using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    Land land;
    PlayerSeedsAndMoney playerUI;


    public GameObject hoePrefab;
    public GameObject wateringCanePrefab;

    public Transform orientation;
    public Transform playerCamera;
    public float interactorDistance = 2f;
    PlayerMovement playerMovement;

    public bool isHoldingHoe;
    public bool isHoldingWateringCane;

    private bool isHoldingItem;
    private GameObject currentItem;

    public Land selectedLand = null;
    Hoe selectedHoe = null;
    WateringCane selectedWateringCane = null;

    GameObject heldItem;    

    public bool lettucePlanting;
    public bool tomatoPlanting;
    public bool carrotPlanting;
    public bool cucumberPlanting;

    public string lettuceTag = "Lettuce";
    public string tomatoTag = "Tomato";

    private void Start()
    {
        
        playerMovement = transform.parent.GetComponent<PlayerMovement>();
        land = FindObjectOfType<Land>();
        playerUI = FindObjectOfType<PlayerSeedsAndMoney>();
        isHoldingItem = false;
        isHoldingHoe = false;
        isHoldingWateringCane = false;
    }

    private void Update()
    {
        Vector3 playerDirection = playerCamera.forward;


        transform.position = playerCamera.position + playerDirection * interactorDistance;
        transform.rotation = Quaternion.LookRotation(playerDirection);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2))
        {
            OnInteractHit(hit);
        }

        lettucePlanting = Input.GetKeyDown(KeyCode.Alpha1);
        tomatoPlanting = Input.GetKeyDown(KeyCode.Alpha2);
        carrotPlanting = Input.GetKeyDown(KeyCode.Alpha3);
        cucumberPlanting = Input.GetKeyDown(KeyCode.Alpha4);
    }


  

    void OnInteractHit(RaycastHit hit)
    {
        Collider other = hit.collider;

        if (other.tag == "Land")
        {
            Land land = other.GetComponent<Land>();
            SelectLand(land);
            if (land.landStatus == Land.LandStatus.Farm || land.landStatus == Land.LandStatus.Watered)
            {
                if (lettucePlanting && playerUI.lettuceAmount > 0 && !land.plant.activeInHierarchy)
                {
                    land.plant.transform.localScale = 2 * new Vector3(0.4f, 0.4f, 0.4f);
                    TogglePlant(land);
                    playerUI.LettucePlant();
                    VegManager.instance.Vegies.Add(land.plant);
                    
                  
                }
                else if (tomatoPlanting && playerUI.tomatoAmount > 0 && !land.plant.activeInHierarchy)
                {
                    TogglePlant(land);
                    land.plant.transform.localScale = 2 * new Vector3(0.4f, 0.4f, 0.4f);
                    playerUI.TomatoPlant();
                    VegManager.instance.Vegies.Add(land.plant);
                    

                }
                else if (carrotPlanting && playerUI.carrotAmount > 0 && !land.plant.activeInHierarchy)
                {
                    TogglePlant(land);
                    land.plant.transform.localScale = 2 * new Vector3(0.4f, 0.4f, 0.4f);
                    playerUI.CarrotPlant();
                    VegManager.instance.Vegies.Add(land.plant);
                    
                }

                else if (cucumberPlanting && playerUI.cucumberAmount > 0 && !land.plant.activeInHierarchy)
                {
                    TogglePlant(land);
                    playerUI.CucumberPlant();
                    land.plant.transform.localScale = 2 * new Vector3(0.4f, 0.4f, 0.4f);
                    VegManager.instance.Vegies.Add(land.plant);
                    
                }
            }
           
            return;

        }

        if (other.tag == "Hoe")
        {
            Hoe hoe = other.GetComponent<Hoe>();
            SelectHoe(hoe);
            return;
        }

        if (other.tag == "WateringCane")
        {
            WateringCane wateringCan = other.GetComponent<WateringCane>();
            SelectWateringCane(wateringCan);
            return;
        }

        if (selectedLand != null)
        {
            selectedLand.Select(false);
            selectedLand = null;
        }

        if (selectedHoe != null)
        {
            selectedHoe.Select(false);
            selectedHoe = null;
        }

        if (selectedWateringCane != null)
        {
            selectedWateringCane.Select(false);
            selectedWateringCane = null;
        }

    }


    void TogglePlant(Land land)
    {
        if (selectedLand != null)
        {
            selectedLand.TogglePlantVisibility(false);
        }

        selectedLand = land;
        land.TogglePlantVisibility(true);

        if (lettucePlanting && playerUI.lettuceAmount > 0)
        {
            land.plant.tag = "Lettuce";
        }
        else if (tomatoPlanting && playerUI.tomatoAmount > 0)
        {
            land.plant.tag = "Tomato";
        }
        else if (carrotPlanting && playerUI.carrotAmount > 0)
        {
            land.plant.tag = "Carrot";
        }
        else if (cucumberPlanting && playerUI.cucumberAmount > 0)
        {
            land.plant.tag = "Cucumber";
        }

    }
    void SelectLand(Land land)
    {
        if (selectedLand != null)
        {
            selectedLand.Select(false);
        }

        selectedLand = land;
        land.Select(true);
    }

    public void SelectHoe(Hoe hoe)
    {
        if (selectedHoe != null)
        {
            selectedHoe.Select(false);
        }

        selectedHoe = hoe;
        hoe.Select(true);
    }

    public void SelectWateringCane(WateringCane wateringCane)
    {
        if (selectedWateringCane != null)
        {
            selectedWateringCane.Select(false);
        }

        selectedWateringCane = wateringCane;
        wateringCane.Select(true);
    }



    public void Interact()
    {
        if (selectedLand != null)
        {
            selectedLand.Interact();

            if (selectedLand.landStatus == Land.LandStatus.Farm || selectedLand.landStatus == Land.LandStatus.Watered)
            {
                if (lettucePlanting && playerUI.lettuceAmount > 0)
                {
                    selectedLand.TogglePlantVisibility(true);
                    playerUI.LettucePlant();
                }
                else if (tomatoPlanting && playerUI.tomatoAmount > 0)
                {
                    selectedLand.TogglePlantVisibility(true);
                    playerUI.TomatoPlant();
                }
                else if (carrotPlanting && playerUI.carrotAmount > 0)
                {
                    selectedLand.TogglePlantVisibility(true);
                    playerUI.CarrotPlant();
                }

                else if (cucumberPlanting && playerUI.cucumberAmount > 0)
                {
                    selectedLand.TogglePlantVisibility(true);
                    playerUI.CucumberPlant();
                }
            }

            return;
        }

        if (selectedHoe != null)
        {
            selectedHoe.Interact(transform);
            if (isHoldingItem && currentItem != null)
            {
                ChangeItem(currentItem);
            }
            currentItem = Instantiate(hoePrefab, transform.position, transform.rotation);
            currentItem.transform.SetParent(transform);
            currentItem.transform.localPosition = new Vector3(0.5f, -0.2f, -1.2f);
            currentItem.transform.localRotation = hoePrefab.transform.localRotation;
            isHoldingItem = true;
            isHoldingHoe = true;
            isHoldingWateringCane = false;
            selectedHoe = null;
            return;
        }

        if (selectedWateringCane != null)
        {
            selectedWateringCane.Interact(transform);
            if (isHoldingItem && currentItem != null)
            {
                ChangeItem(currentItem);
            }
            currentItem = Instantiate(wateringCanePrefab, transform.position, transform.rotation);
            currentItem.transform.SetParent(transform);
            currentItem.transform.localPosition = new Vector3(0.3f, -0.3f, -1.3f);
            currentItem.transform.localRotation = wateringCanePrefab.transform.localRotation;
            isHoldingItem = true;
            isHoldingWateringCane = true;
            isHoldingHoe = false;
            selectedWateringCane = null;
            return;
        }

        
    }
    public void ChangeItem(GameObject newItemPrefab)
    {
        
        if (currentItem != null)
        {
            Destroy(currentItem);
        }

        
        currentItem = Instantiate(newItemPrefab, transform.position, transform.rotation);
        
    }


}