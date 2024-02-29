using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

[SerializeField] private float speed =5f;


//Gun Variables

[SerializeField] private GameObject[] projectile;
[SerializeField] private Transform firingPoint;
[SerializeField] private GameObject pizza;
[SerializeField] private GameObject block;
    [SerializeField] private Animator feet;
    [SerializeField] private Animator body;


    private float fireRate;
private int currentprojectile =0;



private Rigidbody2D rb;
private float mx;
private float my;

private Vector2 mousePos;

private float fireTimer;

public float pizzaCount = 1;
public float blockCount = 3;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw ("Horizontal");
        my = Input.GetAxisRaw ("Vertical");
         mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

         float angle =Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg -90f;
         transform.localRotation = Quaternion.Euler (0,0,angle);

        if(Input.GetKeyDown("1")){
            currentprojectile =0;
            
        }
        else if(Input.GetKeyDown("2")){
            currentprojectile =1;

        }
         else if(Input.GetKeyDown("3")){
            currentprojectile =2;

        }





fireRate = projectile[currentprojectile].GetComponent<Projectile_Motion>().fireRate;

        if (Input.GetMouseButtonDown(0)  && fireTimer <=0f)
        {
            Shoot();
            fireTimer =fireRate;
        }

        else 
        {      
        fireTimer -= Time.deltaTime;
        }



//Spawn a Pizza Distraction
        if(Input.GetKeyDown("p") && pizzaCount>0)
        {
            Debug.Log("Pizza");
            Instantiate (pizza,firingPoint.position,Quaternion.identity);
            pizzaCount-= 1;

        }

//Spawn a Blockade
        if(Input.GetKeyDown("b") && blockCount>0)
        {
            Debug.Log("Blockade");
            Instantiate (block,firingPoint.position,Quaternion.identity);
            blockCount-= 1;

        }



    }
    void FixedUpdate() {
        
        rb.velocity = new Vector2 (mx,my).normalized * speed;

        //Set walking feet animation
        if (rb.velocity.magnitude >0f)
        {
            feet.SetBool("isWalking", true);

        }
        else
        {

            feet.SetBool("isWalking", false);
        }




        //Keep Player on Screen
        if (transform.position.x>21){
            transform.position =new Vector3 (21, transform.position.y,transform.position.z);
        }

        if (transform.position.x<-21){
            transform.position =new Vector3 (-21, transform.position.y,transform.position.z);
        }
        if (transform.position.y>7.5f){
            transform.position =new Vector3 (transform.position.x,7.5f,transform.position.z);
        }

        if (transform.position.y<-8.0f){
            transform.position =new Vector3 (transform.position.x,-8.0f,transform.position.z);
        }
        }

    


private void Shoot()
{

        body.Play("Player_Throw");
Instantiate (projectile[currentprojectile], firingPoint.position,firingPoint.rotation);

}




}
