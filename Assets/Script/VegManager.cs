using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegManager : MonoBehaviour
{
    public static VegManager instance;
    [SerializeField] public List<GameObject> Vegies = new List<GameObject>();



    void Awake() => instance = this;
    private void Start()
    {

        foreach(Transform v in transform)
        {
       
            Vegies.Add(v.gameObject);
          
        }
    }
    public void Growing()
    {
        foreach(var v in Vegies) 
        {

            v.gameObject.GetComponent<Grow>().podrosnij();
            
            if (v.tag == "Delete")
            {
                Vegies.Remove(v);
            }
        }
    }
  

}
