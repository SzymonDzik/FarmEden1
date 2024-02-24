using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCane : MonoBehaviour
{
    public GameObject select;

    public void Interact(Transform playerTransform)
    {
        transform.parent = playerTransform;
        Destroy(gameObject);
    }

    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }
}