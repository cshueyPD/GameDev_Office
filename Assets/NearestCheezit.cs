using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestCheezit : MonoBehaviour
{
    public GameObject[] AllObjects;
  public GameObject NearestOBJ;
  float distance;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        AllObjects = GameObject.FindGameObjectsWithTag("Collectable");
        float nearestDistance = 100;


         if (AllObjects.Length >= 1)
      {
        for (int j = 0; j < AllObjects.Length; j++)
        {

          distance = Vector2.Distance(this.transform.position, AllObjects[j].transform.position);
          


          if (distance < nearestDistance)
          {

            NearestOBJ = AllObjects[j];
            nearestDistance = distance;
            Debug.Log(nearestDistance);
                       
          }

        }
      } 
    }
}
