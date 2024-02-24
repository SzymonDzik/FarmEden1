using UnityEngine;

public class Hoe : MonoBehaviour
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
