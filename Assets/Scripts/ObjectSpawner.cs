using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;        //mouse object
    private PlacementIndicator placementIndicator;      //blue circle
    public bool hasSpawned;     //has the mouse spawned
    private GameObject obj;

    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
        hasSpawned = false;
    }

    //function for place / move button
   public void onClick()
   {
        if (hasSpawned == false)
        {   //instantiate the mouse object
            obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
            hasSpawned = true;      
        }
        else if (hasSpawned == true)
        {   //destroy mouse object
            Destroy(obj, 0.0F);
            hasSpawned = false;
            Start();
        }
   }
}
