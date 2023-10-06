using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    
    public Transform target;
    public float speed =3f;
    public float rotateSpeed = 0.0025f;
   [SerializeField] float health =3f; 
   //[SerializeField] float maxHealth =3f;
   //[SerializeField] floatingHealthBar bar;

    private Rigidbody2D rb;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      //  bar = GetComponent<floatingHealthBar>();
        
    }

    // Update is called once per frame
    void Update()
    {
    // Get the target
    if(!target) 
    {
        GetTarget();
    }
     else
     {
        RotateTowardsTarget();



     }
    
  




    }

void FixedUpdate()
{
// Move forward
rb.velocity = transform.up * speed;


}



private void GetTarget()
{
if( GameObject.FindGameObjectWithTag("Food")){
target = GameObject.FindGameObjectWithTag("Food").transform;
}

}


private void RotateTowardsTarget()
{

Vector2 targetDirection = target.position - transform.position;
float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg -90f;
Quaternion q = Quaternion.Euler (new Vector3(0,0,angle));
transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);

}


private void OnCollisionEnter2D (Collision2D other)
{

if(other.gameObject.CompareTag("Player")){
Destroy(other.gameObject);
target = null;

}else if (other.gameObject.CompareTag("Projectile")){
Destroy(other.gameObject);

health -=1;
//bar.UpdateHealthBar(maxHealth,health);

}


if(health<=0)
{

Destroy(gameObject);
}

}






}
