using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Land : MonoBehaviour
{
    Grow grow;
    PlayerInteraction playerInteraction;
    public enum LandStatus
    {
        Soil,
        Farm,
        Watered
    }


    public LandStatus landStatus;

    public Material soilMat, farmMat, wateredMat;
    new Renderer renderer;

    public GameObject select;

    public GameObject plant;

    PlayerSeedsAndMoney playerUI;
    private void Start()
    {
        playerInteraction = FindObjectOfType<PlayerInteraction>();
       
        renderer = GetComponent<Renderer>();
        SwitchLandStatus(LandStatus.Soil);

        playerUI = FindObjectOfType<PlayerSeedsAndMoney>();
        Select(false);
    }
    public void SwitchLandStatus(LandStatus status)
    {
        landStatus = status;
        Material materialToSwitch = soilMat;

        switch (status)
        {
            case LandStatus.Soil:
                materialToSwitch = soilMat;
                break;
            case LandStatus.Farm:
                materialToSwitch = farmMat;
                break;
            case LandStatus.Watered:
                materialToSwitch = wateredMat;
                break;
                
                
                
        }

        renderer.material = materialToSwitch;
    }

    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }

    public void Interact()
    {
        
        if (playerInteraction.isHoldingHoe && landStatus == LandStatus.Soil)
        {
            SwitchLandStatus(LandStatus.Farm);
        }

        if(playerInteraction.isHoldingWateringCane && landStatus == LandStatus.Farm)
        {
            SwitchLandStatus(LandStatus.Watered);
        }
       
    }

    public void TogglePlantVisibility(bool isVisible)
    {
        
        if (playerInteraction.selectedLand != null && (landStatus == LandStatus.Farm || landStatus == LandStatus.Watered))
        {
            plant.SetActive(isVisible);
        }
    }
}



