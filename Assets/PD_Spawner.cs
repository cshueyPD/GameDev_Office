using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PD_Spawner : MonoBehaviour
{
  public GameObject Cheezit;

  public GameObject[] AllObjects;
  public GameObject NearestOBJ;
  float distance;
  // float nearestDistance = 1000;

  public int numCheezit = 1;  //Number of CheezIts to spawn

  void Start()
  {

    SpawnInZone(-14, -4, 7, 16);
    SpawnInZone(-4, -6, 7, 16);
    SpawnInZone(6, 17, 7, 16);

    SpawnInZone(-14, -4, 16, 24);
    SpawnInZone(-4, 6, 16, 24);
    SpawnInZone(6, 17, 16, 24);


  }





  private int FindCollisions(Vector2 pos)  //Check for collisions
  {
    Collider2D[] hits = Physics2D.OverlapCircleAll(pos, 1f);
    //Debug.Log(hits.Length);
    return hits.Length;


  }


  private void SpawnInZone(float XLow, float XHigh, float YLow, float YHigh)
  {
    float nearestDistance = 100;
    int i = 0;

    while (i < numCheezit)
    {
      float spawnPointX = Random.Range(XLow, XHigh);  //Pick Random X Position
      float spawnPointY = Random.Range(YLow, YHigh);     //Pick Random Y Position
      Vector2 spawnPosition = new Vector2(spawnPointX, spawnPointY);

      AllObjects = GameObject.FindGameObjectsWithTag("Collectable");

      if (AllObjects.Length >= 1)
      {
        for (int j = 0; j < AllObjects.Length; j++)
        {

          distance = Vector2.Distance(spawnPosition, AllObjects[j].transform.position);
          


          if (distance < nearestDistance)
          {

            NearestOBJ = AllObjects[j];
            nearestDistance = distance;
                       
          }

        }
      } 

       
         if(FindCollisions(spawnPosition) < 1)
        {
            Instantiate(Cheezit, spawnPosition, Quaternion.identity);  // If there are no collisions, spawn CheezIt
            i++;
        }
    
  }
}
}