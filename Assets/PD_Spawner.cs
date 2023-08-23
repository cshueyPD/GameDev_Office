using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PD_Spawner : MonoBehaviour
{
   public GameObject Cheezit;
   public int numCheezit =1;  //Number of CheezIts to spawn

void Start()
{
int i=0;

    while (i < numCheezit)
    {
      int spawnPointX = Random.Range(-14,-4);  //Pick Random X Position
      int spawnPointY = Random.Range(7,16);     //Pick Random Y Position
      Vector2 spawnPosition = new Vector2(spawnPointX,spawnPointY);

   if(FindCollisions(spawnPosition)<1)   
   {
   Instantiate (Cheezit,spawnPosition,Quaternion.identity);  // If there are no collisions, spawn CheezIt
   i++;
   }
    }

i=0;
while (i < numCheezit)
    {
      int spawnPointX = Random.Range(-4,6);  //Pick Random X Position
      int spawnPointY = Random.Range(7,16);     //Pick Random Y Position
      Vector2 spawnPosition = new Vector2(spawnPointX,spawnPointY);

   if(FindCollisions(spawnPosition)<1)   
   {
   Instantiate (Cheezit,spawnPosition,Quaternion.identity);  // If there are no collisions, spawn CheezIt
   i++;
   }
    }

i=0;
while (i < numCheezit)
    {
      int spawnPointX = Random.Range(6,17);  //Pick Random X Position
      int spawnPointY = Random.Range(7,16);     //Pick Random Y Position
      Vector2 spawnPosition = new Vector2(spawnPointX,spawnPointY);

   if(FindCollisions(spawnPosition)<1)   
   {
   Instantiate (Cheezit,spawnPosition,Quaternion.identity);  // If there are no collisions, spawn CheezIt
   i++;
   }
    }

i=0;
while (i < numCheezit)
    {
      int spawnPointX = Random.Range(-14,-4);  //Pick Random X Position
      int spawnPointY = Random.Range(16,24);     //Pick Random Y Position
      Vector2 spawnPosition = new Vector2(spawnPointX,spawnPointY);

   if(FindCollisions(spawnPosition)<1)   
   {
   Instantiate (Cheezit,spawnPosition,Quaternion.identity);  // If there are no collisions, spawn CheezIt
   i++;
   }
    }

i=0;
while (i < numCheezit)
    {
      int spawnPointX = Random.Range(-4,6);  //Pick Random X Position
      int spawnPointY = Random.Range(16,24);     //Pick Random Y Position
      Vector2 spawnPosition = new Vector2(spawnPointX,spawnPointY);

   if(FindCollisions(spawnPosition)<1)   
   {
   Instantiate (Cheezit,spawnPosition,Quaternion.identity);  // If there are no collisions, spawn CheezIt
   i++;
   }
    }

i=0;
while (i < numCheezit)
    {
      int spawnPointX = Random.Range(6,17);  //Pick Random X Position
      int spawnPointY = Random.Range(16,24);     //Pick Random Y Position
      Vector2 spawnPosition = new Vector2(spawnPointX,spawnPointY);

   if(FindCollisions(spawnPosition)<1)   
   {
   Instantiate (Cheezit,spawnPosition,Quaternion.identity);  // If there are no collisions, spawn CheezIt
   i++;
   }
    }

}





private int FindCollisions(Vector2 pos)  //Check for collisions
{
Collider2D[] hits = Physics2D.OverlapCircleAll(pos, 1f);
//Debug.Log(hits.Length);
return hits.Length;


}


}
