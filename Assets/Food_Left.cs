using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Left : MonoBehaviour
{
    [SerializeField] private float MaxValue =100f;
    [SerializeField] private float CurrentValue =100f;

    [SerializeField] private float FoodRestock =10f;
    [SerializeField] floatingHealthBar bar;
     
    
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentValue=MaxValue;
        bar = GetComponentInChildren<floatingHealthBar>();


        bar.UpdateHealthBar(MaxValue,CurrentValue);
    }


    // Update is called once per frame 

void Update()
{

bar.UpdateHealthBar(CurrentValue,MaxValue);

if(CurrentValue>MaxValue)
{
    CurrentValue = MaxValue;
}


}




private void OnCollisionStay2D (Collision2D other)
{


if (other.gameObject.CompareTag("Enemy")){

CurrentValue -= other.gameObject.GetComponent<Enemy_Movement>().hunger*Time.deltaTime;


}


if (other.gameObject.CompareTag("Player")){

CurrentValue += FoodRestock*Time.deltaTime;


}



if(CurrentValue<=0)
{

Destroy(gameObject);
FindObjectOfType<gameManager>().EndGame();
}

}


}

