using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza_Left : MonoBehaviour
{
    [SerializeField] private float MaxValue =10f;
    [SerializeField] private float CurrentValue =10f;

    //[SerializeField] private float FoodRestock =0f;
    
    public SpriteRenderer spriteRenderer;
    
    public Sprite[] spriteArray;
     
    
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentValue=MaxValue;
        spriteRenderer.sprite = spriteArray[0];
        
    }


    // Update is called once per frame 

void Update()
{


if(CurrentValue>MaxValue)
{
    CurrentValue = MaxValue;
}

if (CurrentValue/MaxValue<0.875){
    spriteRenderer.sprite = spriteArray[1];
}
if (CurrentValue/MaxValue<0.75){
    spriteRenderer.sprite = spriteArray[2];
}
if (CurrentValue/MaxValue<0.625){
    spriteRenderer.sprite = spriteArray[3];
}
if (CurrentValue/MaxValue<0.5){
    spriteRenderer.sprite = spriteArray[4];
}
if (CurrentValue/MaxValue<0.375){
    spriteRenderer.sprite = spriteArray[5];
}
if (CurrentValue/MaxValue<0.25){
    spriteRenderer.sprite = spriteArray[6];
}
if (CurrentValue/MaxValue<0.125){
    spriteRenderer.sprite = spriteArray[7];
}

}




private void OnCollisionStay2D (Collision2D other)
{


if (other.gameObject.CompareTag("Enemy")){

CurrentValue -= other.gameObject.GetComponent<Enemy_Movement>().hunger*Time.deltaTime;


}


//if (other.gameObject.CompareTag("Player")){

//CurrentValue += FoodRestock*Time.deltaTime;


//}



if(CurrentValue<=0)
{

Destroy(gameObject);
//FindObjectOfType<gameManager>().EndGame();
}

}


}

