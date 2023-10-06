using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Left : MonoBehaviour
{
    [SerializeField] private float MaxValue =100f;
    [SerializeField] private float CurrentValue =100f;
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

}




private void OnCollisionStay2D (Collision2D other)
{


if (other.gameObject.CompareTag("Enemy")){

CurrentValue -= 0.01f;


}


if(CurrentValue<=0)
{

Destroy(gameObject);
}

}


}

