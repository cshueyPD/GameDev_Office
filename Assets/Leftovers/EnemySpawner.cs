using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField] private float spawnRate =1f;

   [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField]  private bool canSpawn = true;


   private void Start()
   {

StartCoroutine (Spawner());



   }

private IEnumerator Spawner()
{

WaitForSeconds wait = new WaitForSeconds(spawnRate);

while(canSpawn)
{
yield return wait;


int rand = Random.Range(1,100);

if (rand<70f)
{
GameObject enemyToSpawn = enemyPrefabs[0];
Instantiate (enemyToSpawn, transform.position, Quaternion.identity);
}

if (rand >70f && rand<90f)
{
GameObject enemyToSpawn = enemyPrefabs[1];
Instantiate (enemyToSpawn, transform.position, Quaternion.identity);
}

if (rand>90f)
{GameObject enemyToSpawn = enemyPrefabs[2]; 
Instantiate (enemyToSpawn, transform.position, Quaternion.identity);
}

//int rand = Random.Range(0, enemyPrefabs.Length);
//GameObject enemyToSpawn = enemyPrefabs[rand];
//Instantiate (enemyToSpawn, transform.position, Quaternion.identity);


}



}




}